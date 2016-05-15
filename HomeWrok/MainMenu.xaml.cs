using HomeWrok.Model;
using HomeWrok.ViewModel;
using Newtonsoft.Json.Linq;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace HomeWrok
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        TopViewModel topViewModel = new TopViewModel();
        findData finddate = new findData();
        pageEvent pageevent = new pageEvent();
        FindViewModel findViewModel = new FindViewModel();
        Pagebean pageBean = new Pagebean();
        SongInfo songinfo = new SongInfo();
        ObservableCollection<Contentlist> contentlist = new ObservableCollection<Contentlist>();
        SQLiteConnection _connection = new SQLiteConnection("playList.db");

        public MainMenu()
        {

            this.InitializeComponent();
            Top.ItemsSource = topViewModel.topOne;
            topViewModel.toJson();
            findTexBox.DataContext = finddate;
            findButton.DataContext = pageevent;
            songListView.ItemsSource = contentlist;
            playlist.ItemsSource = MainViewModel.playList;
            
        }

        private void Top_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //获取点击的第几项目
            foreach (var item in e.AddedItems)
            {
                Listinfo.Num = (item as TopOne).Num;
                Listinfo.Name = (item as TopOne).Topname;
            }
            Frame.Navigate(typeof(DetailTop));
        }
        string songer;
        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            num = 2;
            old = 0;
            contentlist.Clear();
            findSongSL.ChangeView(null, null, null);
            songer = findTexBox.Text;
            jsonDeserialize(songer, 1);

        }
        private async void jsonDeserialize(string songer, int i = 1)
        {
            string c = await findViewModel.myHttpClient(songer, i);
            Json.findJson = JObject.Parse(c);
            //findViewModel.toJson(songer);/
            int m = 30;
            pageBean.allNum = (int)Json.findJson["showapi_res_body"]["pagebean"]["allNum"];
            pageBean.allPages = (int)Json.findJson["showapi_res_body"]["pagebean"]["allPages"];
            if (pageBean.allPages - 1 == num)
                m = pageBean.allNum - 30 * (pageBean.allPages - 1);
            for (int j = 0; j < m/* Json.findJson["showapi_res_body"]["pagebean"]["contentlist"].ToArray().Count()*/; j++)
            {
                Contentlist cl = new Contentlist();
                try { cl.Albumname = Json.findJson["showapi_res_body"]["pagebean"]["contentlist"][j]["albumname"].ToString(); }
                catch { }
                try { cl.Albumpic_big = new BitmapImage(new Uri(Json.findJson["showapi_res_body"]["pagebean"]["contentlist"][j]["albumpic_big"].ToString())); }
                catch { }
                try { cl.Albumpic_small = new BitmapImage(new Uri(Json.findJson["showapi_res_body"]["pagebean"]["contentlist"][j]["albumpic_small"].ToString())); }
                catch { }
                try { cl.DownUrl = Json.findJson["showapi_res_body"]["pagebean"]["contentlist"][j]["downUrl"].ToString(); }
                catch { }
                try { cl.M4a = Json.findJson["showapi_res_body"]["pagebean"]["contentlist"][j]["m4a"].ToString(); }
                catch { }
                try { cl.Songname = Json.findJson["showapi_res_body"]["pagebean"]["contentlist"][j]["songname"].ToString(); }
                catch { }
                try { cl.Songid = (int)Json.findJson["showapi_res_body"]["pagebean"]["contentlist"][j]["songid"]; }
                catch { }
                contentlist.Add(cl);
            }
        }
        int num = 2;
        double old = 0;

        private void SongListSL_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (findSongSL.VerticalOffset > (findSongSL.ScrollableHeight - 300) && (findSongSL.ScrollableHeight != old) && num <= pageBean.allPages)
            {
                jsonDeserialize(findTexBox.Text, num);
                num++;
                old = findSongSL.ScrollableHeight;
            }
        }



        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var statement = _connection.Prepare("INSERT INTO Form VALUES(?,?,?,?,?); "))
            {
                using (var statement2 = _connection.Prepare("SELECT songname FROM Form WHERE Url = ?;"))
                {
                    statement2.Bind(1, Song.Url);

                    SQLiteResult result = statement2.Step();
                    if (SQLiteResult.ROW == result)
                    {
                        await new MessageDialog("已添加此歌").ShowAsync();
                        Debug.Write(statement2[0] as String);
                    }
                    else
                    {

                        SongInfo si = new SongInfo();
                        si.Image = Song.Image;
                        si.Songname = Song.Songname;
                        si.Url = Song.Url;
                        si.Singername = Song.Singername;
                        si.DownUrl = Song.DownUrl;
                        MainViewModel.playList.Add(si);
                        statement.Bind(1, Song.Songname);
                        statement.Bind(2, Song.Singername);
                        statement.Bind(3, Song.DownUrl);
                        statement.Bind(4, Song.Url);
                        statement.Bind(5, Song.Image.ToString());
                        SQLiteResult a = statement.Step();
                    }
                }
            }

        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {

            pageevent.download(Song.Url, Song.Songname + ".mp3");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int record = 0;
            for (int i = 0; i < MainViewModel.playList.Count(); i++)
            {
                if (MainViewModel.playList[i].DownUrl == Song.DownUrl)
                    record = i;
            }

            using (var statement = _connection.Prepare("DELETE FROM Form WHERE DownUrl = ?;"))
            {
                statement.Bind(1, Song.DownUrl);
                statement.Step();
            }

            MainViewModel.playList.RemoveAt(record);
        }
    }

}