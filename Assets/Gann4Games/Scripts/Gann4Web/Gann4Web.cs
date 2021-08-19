using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Gann4Games.Thirdym.Gann4Web
{
    public class Gann4Web
    {
        public bool IsServerDown 
        {
            get
            {
                try
                {
                    GetLastVersion();
                    return false;
                }
                catch(WebException)
                {
                    return true;
                }
            }
        }

        readonly string _url = "http://gann4life.ga/json/data.json";
        WebClient _client;

        class CloudData { public Dictionary<string, Dictionary<string, string>> games = new Dictionary<string, Dictionary<string, string>>(); }
        string GetVersionString(string content)
        {
            CloudData _data = new CloudData();
            _data = JsonConvert.DeserializeObject<CloudData>(content);
            return _data.games["thirdym"]["version"];
        }
        public string GetLastVersion()
        {
            _client = new WebClient();
            return GetVersionString(_client.DownloadString(_url));
        }
        public string GetCurrentVersion() => UnityEngine.Application.version;
    }
}
