using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace HomeWrok.Model
{
    public class SongInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        private  BitmapImage image;
        private  string songname;

        public  BitmapImage Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public  string Songname
        {
            get
            {
                return songname;
            }

            set
            {
                songname = value;
                OnPropertyChanged("Songname");
            }
        }
        private  string url;
        private  string singername;
        private  string downUrl;
        public  string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }


  

        public  string Singername
        {
            get
            {
                return singername;
            }

            set
            {
                singername = value;
            }
        }

        public  string DownUrl
        {
            get
            {
                return downUrl;
            }

            set
            {
                downUrl = value;
            }
        }

    }
    //页面传值
    public static class Song
    {
        private static string url;
        private static string songname;
        private static BitmapImage image;
        private static string singername;
        private static string downUrl;
        public static string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

  
        public static BitmapImage Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public static string Songname
        {
            get
            {
                return songname;
            }

            set
            {
                songname = value;
            }
        }

        public static string Singername
        {
            get
            {
                return singername;
            }

            set
            {
                singername = value;
            }
        }

        public static string DownUrl
        {
            get
            {
                return downUrl;
            }

            set
            {
                downUrl = value;
            }
        }
    }
}
