using System.Xml.Linq;

namespace OtenkiBotCore.Forecast.Yahoo
{
    public interface IYahooRequestor
    {
        XDocument GetFeed(string url);
    }
}
