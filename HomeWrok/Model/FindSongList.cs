using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace HomeWrok.Model
{

    public class Rootobject
    {
        public int showapi_res_code { get; set; }
        public string showapi_res_error { get; set; }
        public Showapi_Res_Body showapi_res_body { get; set; }
    }

    public class Showapi_Res_Body
    {
        public Pagebean pagebean { get; set; }
    }

    public class Pagebean
    {
        public int allNum { get; set; }
        public int allPages { get; set; }
        public Contentlist[] contentlist { get; set; }
        public int currentPage { get; set; }
        public int maxResult { get; set; }
        public string notice { get; set; }
        public string w { get; set; }
    }

    public class Contentlist
    {
        private int albumid;
        private string albummid;
        private string albumname;
        private BitmapImage albumpic_big;
        private BitmapImage albumpic_small;
        private string downUrl;
        private string m4a;
        private int singerid;
        private string singername;
        private int songid;
        private string songmid;
        private string songname;
        private string media_mid;

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

        public string Albumname
        {
            get
            {
                return albumname;
            }

            set
            {
                albumname = value;
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

        public string M4a
        {
            get
            {
                return m4a;
            }

            set
            {
                m4a = value;
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

        public string Songmid
        {
            get
            {
                return songmid;
            }

            set
            {
                songmid = value;
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

        public string Media_mid
        {
            get
            {
                return media_mid;
            }

            set
            {
                media_mid = value;
            }
        }
    }

}
