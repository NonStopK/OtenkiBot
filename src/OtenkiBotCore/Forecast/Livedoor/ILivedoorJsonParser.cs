using System.Net;

namespace OtenkiBotCore.Forecast.Livedoor
{
    public interface ILivedoorJsonParser
    {
        LivedoorForecasts Parse(HttpWebResponse res);
    }
}
