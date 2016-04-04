using System.Net;
using System.Runtime.Serialization.Json;

namespace OtenkiBotCore.Forecast.Livedoor
{
    public class LivedoorJsonParser : ILivedoorJsonParser
    {
        public LivedoorForecasts Parse(HttpWebResponse res)
        {
            var serializer = new DataContractJsonSerializer(typeof(LivedoorForecasts));
            var obj = serializer.ReadObject(res.GetResponseStream());
            return obj as LivedoorForecasts;
        }
    }
}
