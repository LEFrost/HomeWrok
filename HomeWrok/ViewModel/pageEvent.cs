using HomeWrok.Model;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace HomeWrok.ViewModel
{
    public class pageEvent
    {

        public void SelectionSongSonglist(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                try { Song.Url = (item as Songlist).Url; }
                catch { }
                try { Song.Songname = (item as Songlist).Songname; }
                catch { }
                try { Song.Image = (item as Songlist).Albumpic_small; }
                catch { }
                try { Song.DownUrl = (item as Songlist).DownUrl; }
                catch { }
                try
                { Song.Singername = (item as Songlist).Singername; }
                catch { }
            }
        }
        public void SelectionSongContentlist(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                try { Song.Url = (item as Contentlist).M4a; }
                catch { }
                try { Song.Songname = (item as Contentlist).Songname; }
                catch { }
                try { Song.Image = (item as Contentlist).Albumpic_small; }
                catch { }
                try { Song.DownUrl = (item as Contentlist).DownUrl; }
                catch { }
                try
                { Song.Singername = (item as Contentlist).Singername; }
                catch { }
            }
        }
        public void SelectionSongplayList(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                try { Song.Url = (item as SongInfo).Url; }
                catch { }
                try { Song.Songname = (item as SongInfo).Songname; }
                catch { }
                try { Song.Image = (item as SongInfo).Image; }
                catch { }
                try { Song.DownUrl = (item as SongInfo).DownUrl; }
                catch { }
                try
                { Song.Singername = (item as SongInfo).Singername; }
                catch { }
            }
        }
        public async void download(string url, string name)
        {
           
            //FileSavePicker savepicker = new FileSavePicker();
            //savepicker.SuggestedStartLocation = PickerLocationId.Downloads;
            if (url != null)
            {
                if (name == null)
                    name = "unkown";
                StorageFolder fold = await ApplicationData.Current.LocalFolder.CreateFolderAsync("songFold", CreationCollisionOption.OpenIfExists);
                StorageFile file = await fold.CreateFileAsync(name, CreationCollisionOption.OpenIfExists);
                BackgroundDownloader backgroundDownloader = new BackgroundDownloader();
                DownloadOperation download = backgroundDownloader.CreateDownload(new Uri(url), file);
                await download.StartAsync();
            }

        }
    }
}
