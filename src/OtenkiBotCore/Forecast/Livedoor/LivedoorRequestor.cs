using System;
using System.Net;

namespace OtenkiBotCore.Forecast.Livedoor
{
    public class LivedoorRequestor : ILivedoorRequestor
    {
        private const string REQUEST_URI_FORMAT = "{0}?city={1}";

        private const string SERVER_ERROR_FORMAT = "Server error (HTTP {0}: {1}).";

        private readonly string _uri = "http://weather.livedoor.com/forecast/webservice/json/v1";

        public LivedoorRequestor(string uri)
        {
            _uri = uri;
        }

        public HttpWebResponse GetForecast(string code)
        {
            var uri = string.Format(REQUEST_URI_FORMAT, _uri, code);
            var req = WebRequest.Create(uri) as HttpWebRequest;
            var res = req.GetResponse() as HttpWebResponse;
            if (res.StatusCode != HttpStatusCode.OK)
            {
                var msg = string.Format(SERVER_ERROR_FORMAT, res.StatusCode, res.StatusDescription);
                throw new Exception(msg);
            }
            return res;
        }
    }
}
