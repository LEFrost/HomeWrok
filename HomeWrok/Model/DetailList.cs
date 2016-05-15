using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace HomeWrok.Model
{
    public class Songlist
    {
        private int albumid;
        private string albummid;
        private BitmapImage albumpic_big;
        private BitmapImage albumpic_small;
        private string downUrl;
        private int seconds;
        private int singerid;
        private string singername;
        private int songid;
        private string songname;
        private string url;

        public int Albumid
        {
            get
            {
                return albumid;
            }

            set
            {
                albumid = value;
            }
        }

        public string Albummid
        {
            get
            {
                return albummid;
            }

            set
            {
                albummid = value;
            }
        }

        public BitmapImage Albumpic_big
        {
            get
            {
                return albumpic_big;
            }

            set
            {
                albumpic_big = value;
            }
        }

        public BitmapImage Albumpic_small
        {
            get
            {
                return albumpic_small;
            }

            set
            {
                albumpic_small = value;
            }
        }

        public string DownUrl
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

        public int Seconds
        {
            get
            {
                return seconds;
            }

            set
            {
                seconds = value;
            }
        }

        public int Singerid
        {
            get
            {
                return singerid;
            }

            set
            {
                singerid = value;
            }
        }

        public string Singername
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

        public int Songid
        {
            get
            {
                return songid;
            }

            set
            {
                songid = value;
            }
        }

        public string Songname
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

        public string Url
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
    }
     public class ListName
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
    public static class Listinfo
    {
        private static int num;
        private static string name;
        public static int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }

        public static string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }

}
