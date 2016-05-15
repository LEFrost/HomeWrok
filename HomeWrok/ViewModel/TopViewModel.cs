using HomeWrok.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace HomeWrok.ViewModel
{
    public class TopViewModel : BaseViewModel
    {
        public ObservableCollection<TopOne> topOne = new ObservableCollection<TopOne>();
        List<KeyValuePair<string, string>> paramList = new List<KeyValuePair<string, string>>();//post才有

        string uri = "http://route.showapi.com/213-4";

        async Task<string> myHttpClient(int topid)
        {
            paramList.Add(new KeyValuePair<string, string>("topid", topid.ToString()));
            string content = "";
            try
            {
                return await Task.Run(() =>
                {
                    HttpClient httpclient = new HttpClient();
                    HttpResponseMessage response;
                    response = httpclient.PostAsync(new Uri(uri), new FormUrlEncodedContent(paramList)).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        content = response.Content.ReadAsStringAsync().Result;
                    paramList.RemoveAt(2);
                    return content;
                });
            }
            catch
            {
                Debug.Write("请求失败");
                return "";
            }
        }

        public async void toJson()
        {
            paramList.Add(new KeyValuePair<string, string>("showapi_appid", "18985"));
            paramList.Add(new KeyValuePair<string, string>("showapi_sign", "86061db637874580949c787e22e0f8ba"));
            int[] id = { 3, 5, 6, 16, 17, 18, 19, 23, 26 };
            for (int i = 0; i < 9; i++)
            {
                string content = await myHttpClient(id[i]);
                Json.json[i] = JObject.Parse(content);
                topOne.Add(new TopOne
                {
                    Num=i,
                    Topname = topName(id[i]),
                    Albumpic = new BitmapImage(new Uri(Json.json[i]["showapi_res_body"]["pagebean"]["songlist"][0]["albumpic_small"].ToString()))
                });
            }
        }
        string topName(int x)
        {
            switch (x)
            {
                case 3:
                    return "欧美";
                case 5:
                    return "内地";
                case 6:
                    return "港台";
                case 16:
                    return "韩国";
                case 17:
                    return "日本";
                case 18:
                    return "民谣";
                case 19:
                    return "摇滚";
                case 23:
                    return "销量";
                case 26:
                    return "热歌";
                default:
                    return "";
            }
        }
    }
}
