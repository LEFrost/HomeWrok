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
using Windows.UI.Popups;

namespace HomeWrok.ViewModel
{
    public class FindViewModel : BaseViewModel
    {
        List<KeyValuePair<string, string>> paramList = new List<KeyValuePair<string, string>>();//post才有
 
        string uri = "http://route.showapi.com/213-1";

        //public async void toJson(string name)
        //{

        //    string content = await myHttpClient(name);
        //    Json.findJson = JObject.Parse(content);
        //}
        public async Task<string> myHttpClient(string name, int pagenum)
        {
            paramList.Add(new KeyValuePair<string, string>("showapi_appid", "18985"));
            paramList.Add(new KeyValuePair<string, string>("showapi_sign", "86061db637874580949c787e22e0f8ba"));
            paramList.Add(new KeyValuePair<string, string>("keyword", name));
            paramList.Add(new KeyValuePair<string, string>("page", pagenum.ToString()));
            string content = "";
            try
            {
                return await Task.Run(() =>
                {
                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = httpClient.PostAsync(new Uri(uri), new FormUrlEncodedContent(paramList)).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        content = response.Content.ReadAsStringAsync().Result;
                    paramList.Clear();
                    return content;
                });
            }
            catch
            {
                await new MessageDialog("网络请求失败").ShowAsync();
                return "";
            }
        }
        //public async Task<string> myHttpClient(string name)
        // {
        //     paramList.Add(new KeyValuePair<string, string>("showapi_appid", "18985"));
        //     paramList.Add(new KeyValuePair<string, string>("showapi_sign", "86061db637874580949c787e22e0f8ba"));
        //     paramList.Add(new KeyValuePair<string, string>("keyword", name));
        //     string content = "";
        //     try
        //     {
        //         return await Task.Run(() =>
        //         {
        //             HttpClient httpclient = new HttpClient();
        //             HttpResponseMessage response;
        //             response = httpclient.PostAsync(new Uri(uri), new FormUrlEncodedContent(paramList)).Result;
        //             if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                 content = response.Content.ReadAsStringAsync().Result;
        //             paramList.RemoveAt(2);
        //             return content;
        //         });
        //     }
        //     catch
        //     {
        //         Debug.Write("请求失败");
        //         return "";
        //     }
        // }

    }
}
