using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OtenkiBotCore.Forecast.Yahoo;
using System.Reflection;

namespace OtenkiBotCoreTest.Forecast.Yahoo
{
    [TestFixture]
    public class CustomForecastCreatorTest
    {
        private const string REQUEST_URI = "http://rss.weather.yahoo.co.jp/rss/days/4310.xml";

        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void CreateTest()
        {
            // Arrange
            var feed = new YahooRequestor().GetFeed(REQUEST_URI);
            var yList = new YahooXmlParser().Parse(feed);

            // Act
            var cList = new CustomForecastCreator().Create(yList);

            // Assert
            Assert.IsTrue(0 < cList.Count);
        }

        [TestCase("【 1日（木） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "1日（木）")]
        [TestCase("【 2日（金） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "2日（金）")]
        [TestCase("【 3日（土） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "3日（土）")]
        [TestCase("【 4日（日） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "4日（日）")]
        [TestCase("【 5日（月） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "5日（月）")]
        [TestCase("【 6日（火） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "6日（火）")]
        [TestCase("【 7日（水） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "7日（水）")]
        [TestCase("【 8日（木） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "8日（木）")]
        [TestCase("【 9日（金） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "9日（金）")]
        [TestCase("【 10日（土） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "10日（土）")]
        [TestCase("【 11日（日） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "11日（日）")]
        [TestCase("【 12日（月） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "12日（月）")]
        [TestCase("【 13日（火） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "13日（火）")]
        [TestCase("【 14日（水） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "14日（水）")]
        [TestCase("【 15日（木） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "15日（木）")]
        [TestCase("【 16日（金） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "16日（金）")]
        [TestCase("【 17日（土） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "17日（土）")]
        [TestCase("【 18日（日） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "18日（日）")]
        [TestCase("【 19日（月） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "19日（月）")]
        [TestCase("【 20日（火） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "20日（火）")]
        [TestCase("【 21日（水） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "21日（水）")]
        [TestCase("【 22日（木） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "22日（木）")]
        [TestCase("【 23日（金） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "23日（金）")]
        [TestCase("【 24日（土） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "24日（土）")]
        [TestCase("【 25日（日） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "25日（日）")]
        [TestCase("【 26日（月） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "26日（月）")]
        [TestCase("【 27日（火） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "27日（火）")]
        [TestCase("【 28日（水） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "28日（水）")]
        [TestCase("【 29日（木） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "29日（木）")]
        [TestCase("【 30日（金） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "30日（金）")]
        [TestCase("【 31日（土） 南部（さいたま） 】 晴時々曇 - 6℃/0℃ - Yahoo!天気・災害", "31日（土）")]
        [TestCase("【 南中部 】注意報があります - Yahoo!天気・災害", "南中部")]
        public void GetDayTest(string arg, string actual)
        {
            // Arrange
            object[] args = { arg };
            var type = typeof(CustomForecastCreator);
            object instance = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            // Act
            object obj = type.InvokeMember("GetDay", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, instance, args);
            
            // Assert
            Assert.AreEqual(obj.ToString(), actual);
        }

        [TestCase("")]
        [TestCase(null)]
        public void GetDayInvalidTest(string arg)
        {
            // Arrange
            object[] args = { arg };
            var type = typeof(CustomForecastCreator);
            object instance = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            // Act
            object obj = type.InvokeMember("GetDay", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, instance, args);

            // Assert
            Assert.AreEqual(obj.ToString(), string.Empty);
        }

        [TestCase("晴れ - 7℃/-5℃", "晴れ")]
        [TestCase("曇り - 16℃/12℃", "曇り")]
        [TestCase("雨 - 12℃/9℃", "雨")]
        [TestCase("雪 - 2℃/-2℃", "雪")]
        [TestCase("晴時々曇 - 6℃/0℃", "晴時々曇")]
        [TestCase("曇時々晴 - 7℃/0℃", "曇時々晴")]
        [TestCase("曇時々雨 - 10℃/1℃", "曇時々雨")]
        [TestCase("曇時々雪 - 4℃/-1℃", "曇時々雪")]
        [TestCase("雪時々曇 - -2℃/-5℃", "雪時々曇")]
        [TestCase("晴後曇 - 6℃/-4℃", "晴後曇")]
        [TestCase("晴後雪 - 1℃/-8℃", "晴後雪")]
        [TestCase("曇後晴 - 18℃/13℃", "曇後晴")]
        [TestCase("曇後雨 - 15℃/7℃", "曇後雨")]
        [TestCase("曇後雪 - 5℃/0℃", "曇後雪")]
        [TestCase("雪後曇 - 3℃/-2℃", "雪後曇")]
        [TestCase("暴風雪 - 2℃/0℃", "暴風雪")]
        [TestCase("注意報があります", "注意報があります")]
        public void GetForecastTest(string arg, string actual)
        {
            // Arrange
            object[] args = { arg };
            var type = typeof(CustomForecastCreator);
            object instance = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            // Act
            object obj = type.InvokeMember("GetForecast", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, instance, args);

            // Assert
            Assert.AreEqual(obj.ToString(), actual);
        }

        [TestCase("")]
        [TestCase(null)]
        public void GetForecastInvalidTest(string arg)
        {
            // Arrange
            object[] args = { arg };
            var type = typeof(CustomForecastCreator);
            object instance = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            // Act
            object obj = type.InvokeMember("GetForecast", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, instance, args);

            // Assert
            Assert.AreEqual(obj.ToString(), string.Empty);
        }

        [TestCase("曇り - 16℃/12℃", "16℃", "12℃")]
        [TestCase("晴れ - 7℃/-5℃", "7℃", "-5℃")]
        [TestCase("雪時々曇 - -2℃/-5℃", "-2℃", "-5℃")]
        public void GetTemperatureTest(string arg, string actualMax, string actualMin)
        {
            // Arrange
            object[] args = { arg };
            var type = typeof(CustomForecastCreator);
            object instance = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            // Act
            object obj = type.InvokeMember("GetTemperature", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, instance, args);

            // Assert
            var t = obj as Temperature;
            Assert.AreEqual(t.Max, actualMax);
            Assert.AreEqual(t.Min, actualMin);
        }

        [TestCase("注意報があります")]
        [TestCase("")]
        [TestCase(null)]
        public void GetTemperatureInvalidTest(string arg)
        {
            // Arrange
            object[] args = { arg };
            var type = typeof(CustomForecastCreator);
            object instance = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            // Act
            object obj = type.InvokeMember("GetTemperature", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, instance, args);

            // Assert
            var t = obj as Temperature;
            Assert.AreEqual(t.Max, null);
            Assert.AreEqual(t.Min, null);
        }

        [TestCase("1日（木）")]
        [TestCase("2日（金）")]
        [TestCase("3日（土）")]
        [TestCase("4日（日）")]
        [TestCase("5日（月）")]
        [TestCase("6日（火）")]
        [TestCase("7日（水）")]
        [TestCase("8日（木）")]
        [TestCase("9日（金）")]
        [TestCase("10日（土）")]
        [TestCase("11日（日）")]
        [TestCase("12日（月）")]
        [TestCase("13日（火）")]
        [TestCase("14日（水）")]
        [TestCase("15日（木）")]
        [TestCase("16日（金）")]
        [TestCase("17日（土）")]
        [TestCase("18日（日）")]
        [TestCase("19日（月）")]
        [TestCase("20日（火）")]
        [TestCase("21日（水）")]
        [TestCase("22日（木）")]
        [TestCase("23日（金）")]
        [TestCase("24日（土）")]
        [TestCase("25日（日）")]
        [TestCase("26日（月）")]
        [TestCase("27日（火）")]
        [TestCase("28日（水）")]
        [TestCase("29日（木）")]
        [TestCase("30日（金）")]
        [TestCase("31日（土）")]
        public void GetRelativeDayTest(string arg)
        {
            // Arrange
            object[] args = { arg };
            var type = typeof(CustomForecastCreator);
            object instance = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            // Act
            object obj = type.InvokeMember("GetRelativeDay", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, instance, args);

            // Assert
            var b = (obj as bool?) ?? false;
            Assert.IsTrue(b);
        }

        [TestCase("南中部")]
        [TestCase("")]
        [TestCase(null)]
        public void GetRelativeDayInvalidTest(string arg)
        {
            // Arrange
            object[] args = { arg };
            var type = typeof(CustomForecastCreator);
            object instance = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            // Act
            object obj = type.InvokeMember("GetRelativeDay", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, instance, args);

            // Assert
            var b = (obj as bool?) ?? false;
            Assert.IsFalse(b);
        }

    }
}
