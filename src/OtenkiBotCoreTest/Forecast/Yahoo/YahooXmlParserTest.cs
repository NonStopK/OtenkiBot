using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OtenkiBotCore.Forecast.Yahoo;

namespace OtenkiBotCoreTest.Forecast.Yahoo
{
    [TestFixture]
    public class YahooXmlParserTest
    {
        private const string REQUEST_URI = "http://rss.weather.yahoo.co.jp/rss/days/4310.xml";

        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void ParseTest()
        {
            // Arrange
            var feed = new YahooRequestor().GetFeed(REQUEST_URI);

            // Act
            var list = new YahooXmlParser().Parse(feed);

            // Assert
            Assert.IsTrue(0 < list.Count);
        }
    }
}
