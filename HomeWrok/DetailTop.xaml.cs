using HomeWrok.Model;
using HomeWrok.ViewModel;
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
using Windows.UI.Core;
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
    public sealed partial class DetailTop : Page
    {
        ObservableCollection<Songlist> songlist = new ObservableCollection<Songlist>();
        ListName ln = new ListName();
        pageEvent pageevent = new pageEvent();
        int num = 0;//记录加载的歌数
        SQLiteConnection _connection = new SQLiteConnection("playList.db");
        public DetailTop()
        {
            this.InitializeComponent();
            //返回键
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += BakcRequested;

            songListView.DataContext = pageevent;

            songListView.ItemsSource = songlist;
            header.DataContext = ln;

            ln.Name = Listinfo.Name;
            #region json反序列化
            for (int i = 0; i < 20; i++)
            {
                songlist.Add(jsonDeserialize(i));
            }
            #endregion
        }
        private Songlist jsonDeserialize(int i)
        {
            Songlist sl = new Songlist();

            try
            {
                sl.Albumpic_small = new BitmapImage(new Uri(Json.json[Listinfo.Num]["showapi_res_body"]["pagebean"]["songlist"][i]["albumpic_small"].ToString()));
            }
            catch
            {

            }
            try
            {
                sl.Albumpic_big = new BitmapImage(new Uri(Json.json[Listinfo.Num]["showapi_res_body"]["pagebean"]["songlist"][i].ToString()));

            }
            catch
            {

            }
            try
            {
                sl.DownUrl = Json.json[Listinfo.Num]["showapi_res_body"]["pagebean"]["songlist"][i]["downUrl"].ToString();

            }
            catch
            {

            }
            try
            {
                sl.Singername = Json.json[Listinfo.Num]["showapi_res_body"]["pagebean"]["songlist"][i]["singername"].ToString();
            }
            catch
            {

            }
            try
            {
                sl.Songname = Json.json[Listinfo.Num]["showapi_res_body"]["pagebean"]["songlist"][i]["songname"].ToString();

            }
            catch
            {

            }
            try
            {
                sl.Url = Json.json[Listinfo.Num]["showapi_res_body"]["pagebean"]["songlist"][i]["url"].ToString();

            }
            catch
            {

            }
            return sl;
        }

        private void BakcRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(MainMenu));
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

        }

        private void songListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MediaElement media = new MediaElement();
            foreach (var item in e.AddedItems)
            {
                media.Source = new Uri((item as Songlist).Url);
            }
            media.Play();
        }
        double old = 0;

        private async void SongListSL_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (songlist.Count <= 80)
            {

                int i = num = songlist.Count;
                if (SongListSL.VerticalOffset > (SongListSL.ScrollableHeight - 400) && (SongListSL.ScrollableHeight != old))
                {
                    for (; (num < i + 20) && num < Json.json[Listinfo.Num]["showapi_res_body"]["pagebean"]["songlist"].Count(); num++)
                        songlist.Add(jsonDeserialize(num));
                    old = SongListSL.ScrollableHeight;
                }
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
                        try { statement.Bind(1, Song.Songname); }
                        catch { }
                        try { statement.Bind(2, Song.Singername); }
                        catch { }
                        try { statement.Bind(3, Song.DownUrl); }
                        catch { }
                        try { statement.Bind(4, Song.Url); }
                        catch { }
                        try { statement.Bind(5, Song.Image.UriSource.ToString()); }
                        catch { }
                        SQLiteResult a = statement.Step();
                        
                    }
                }

            }

        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            pageevent.download(Song.Url, Song.Songname + ".mp3");
        }

    }
}

