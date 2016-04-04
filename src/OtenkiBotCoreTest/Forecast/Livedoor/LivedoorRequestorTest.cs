using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OtenkiBotCore.Forecast.Livedoor;
using System.Net;

namespace OtenkiBotCoreTest.Forecast.Livedoor
{
    [TestFixture]
    public class HttpRequestorTest
    {
        private const string REQUEST_URI = "http://weather.livedoor.com/forecast/webservice/json/v1";

        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void LivedoorRequestTest()
        {
            ILivedoorRequestor req = new LivedoorRequestor(REQUEST_URI);
            var res = req.GetForecast("110010");

            Assert.AreEqual(HttpStatusCode.OK, res.StatusCode);
        }
    }
}
