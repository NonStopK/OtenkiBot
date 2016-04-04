using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OtenkiBotCore.Forecast.Yahoo
{
    public class YahooXmlParser : IYahooXmlParser
    {
        public List<YahooForecast> Parse(XDocument feed)
        {
            var list = new List<YahooForecast>();
            list = (from item in feed.Descendants("item")
                    select new YahooForecast
                    {
                        Title = item.Element("title").Value,
                        Link = new Uri(item.Element("link").Value),
                        Description = item.Element("description").Value,
                        PubDate = item.Element("pubDate").Value
                    }).ToList();
            return list;
        }
    }
}