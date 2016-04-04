using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OtenkiBotCore.Forecast.Yahoo;
using System.Net;

namespace OtenkiBotCoreTest.Forecast.Yahoo
{
    [TestFixture]
    public class YahooRequestorTest
    {
        private const string REQUEST_URI = "http://rss.weather.yahoo.co.jp/rss/days/4310.xml";

        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void GetFeedTest()
        {
            IYahooRequestor req = new YahooRequestor();
            var res = req.GetFeed(REQUEST_URI);

            Assert.IsNotNull(res);
        }
    }
}
