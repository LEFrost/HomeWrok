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
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace HomeWrok
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ApplicationDataContainer localSetting;
        SongInfo songinfo = new SongInfo();
        pageEvent pageevent = new pageEvent();
        SQLiteConnection _connection = new SQLiteConnection("playList.db");
        bool isPlay = false;

        public MainPage()
        {
            this.InitializeComponent();
            localSetting = ApplicationData.Current.LocalSettings;
            mainFram.Navigate(typeof(MainMenu));
            play.DataContext = pageevent;
            nowSongimage.DataContext = songinfo;
            nowSongName.DataContext = songinfo;
            if (localSetting.Values.ContainsKey("volume"))
            {
                media.Volume = (double)localSetting.Values["volume"];
                slider.Value = media.Volume * 100;
            }
            CREATETable();
        }
        private void CREATETable()
        {
            using (var statement = _connection.Prepare("CREATE TABLE IF NOT EXISTS Form(songname CHAR(30),singername CHAR(30),downUrl CHAR(100),Url CHAR(100),image CHAR(100));"))
            {
                statement.Step();
            }
        }
   
        private async void play_Click(object sender, RoutedEventArgs e)
        {
            if (!isPlay && Song.Url != null)
            {
              
                if (media.Source != new Uri(Song.Url))
                {
                    media.Source = new Uri(Song.Url);
                }
                media.Play();
                songinfo.Image = Song.Image;
                songinfo.Songname = Song.Songname;
                playicon.Glyph = "";
                isPlay = true;

            }
            else if (Song.Url == null)
                await new MessageDialog("请选择歌曲!!!").ShowAsync();
            else
            {
                
                media.Pause();
                playicon.Glyph = "";
                isPlay = false;
            }

        }


        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            media.Volume = (sender as Slider).Value / 100;
            localSetting.Values["volume"] = media.Volume;
        }

    }
}
