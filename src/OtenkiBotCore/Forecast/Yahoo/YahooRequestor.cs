using System;
using System.Xml.Linq;

namespace OtenkiBotCore.Forecast.Yahoo
{
    public class YahooRequestor : IYahooRequestor
    {
        public XDocument GetFeed(string uri)
        {
            try
            {
                var u = new Uri(uri);
                return XDocument.Load(u.AbsoluteUri);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
