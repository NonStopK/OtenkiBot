using System.Net;

namespace OtenkiBotCore.Forecast.Livedoor
{
    public interface ILivedoorRequestor
    {
        HttpWebResponse GetForecast(string code);
    }
}
