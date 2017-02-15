using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using HoneyComb.BusinessObjects;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HoneyComb.MobileUI.Droid.Services
{
    public class HoneyCombService:IServiceDelegates, IDisposable
    {
        HttpClient _httpClient;
        HttpResponseMessage _response;

        public HoneyCombService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.MaxResponseContentBufferSize = 256000;
        }

        public async void GetObject(IServiceDeletegate<object> handler, GetAction action, params object[] prms)
        {
            try
            {
                var uri = new Uri(String.Format(Config.BASE_SERVICE_URL + action.Url + String.Join("/", prms), string.Empty));


                _response = await _httpClient.GetAsync(uri).ConfigureAwait(false); ;
                if (_response.IsSuccessStatusCode)
                {
                    JsonSerializerSettings serSettings = new JsonSerializerSettings();
                    serSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    var data = _response.Content.ReadAsStringAsync();

                    handler.HandleServiceResults(data.Result, true, string.Empty);
                }
                else
                    handler.HandleServiceResults(null, false, "Failed to connect to the web server, verify that you have airtime or switch off mobile data to work offline");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("A task was canceled"))
                    handler.HandleServiceResults(null, false, "Failed to connect to the web server, verify that you have airtime or switch off mobile data to work offline");
                else
                    handler.HandleServiceResults(null, false, ex.Message);
            }
        }
     


        public async void PostObject(IPostServiceDelegate<object> handler, PostObject<object> postObject)
        {
            ResultObj<object> result = new ResultObj<object>();

            try
            {
                var uri = new Uri(String.Format(Config.BASE_SERVICE_URL + postObject.PostAction.Url));
                var json = JsonConvert.SerializeObject(postObject);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                _response = await _httpClient.PostAsync(uri, content);
                if (_response.IsSuccessStatusCode)
                {
                    JsonSerializerSettings serSettings = new JsonSerializerSettings();
                    serSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    var data = _response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<ResultObj<object>>(data.ToString());
                    handler.HandlePostResults(result);
                }
            }
            catch (Exception ex)
            {
                result.isSuccessful = false;
                result.Error = ex.Message;
                handler.HandlePostResults(result);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}