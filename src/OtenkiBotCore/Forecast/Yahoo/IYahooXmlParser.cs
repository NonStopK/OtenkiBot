using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml.Linq;

namespace OtenkiBotCore.Forecast.Yahoo
{
    public interface IYahooXmlParser
    {
        List<YahooForecast> Parse(XDocument feed);
    }
}
