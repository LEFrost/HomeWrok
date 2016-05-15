using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace HomeWrok.Model
{


    //public class Rootobject
    //{
    //    public int showapi_res_code { get; set; }
    //    public string showapi_res_error { get; set; }
    //    public Showapi_Res_Body showapi_res_body { get; set; }
    //}

    //public class Showapi_Res_Body
    //{
    //    public Pagebean pagebean { get; set; }
    //    public int ret_code { get; set; }
    //}

    //public class Pagebean
    //{
    //    public int song_begin { get; set; }
    //    public Songlist[] songlist { get; set; }
    //    public int total_song_num { get; set; }
    //    public int totalpage { get; set; }
    //}


    public class TopOne
    {
        /// <summary>
        /// 列表数
        /// </summary>
        private int num;
        private string topname;
        private BitmapImage albumpic;
        public string Topname
        {
            get
            {
                return topname;
            }

            set
            {
                topname = value;
            }
        }

        public BitmapImage Albumpic
        {
            get
            {
                return albumpic;
            }

            set
            {
                albumpic = value;
            }
        }

        public int Num
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
    }
    
    
}

