using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OtenkiBotCore.Entity;
using OtenkiBotCore.Logic;

namespace OtenkiBotCoreTest.Logic
{
    [TestFixture]
    public class ForecastDayLogicTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [TestCase("今日", 0)]
        [TestCase("きょう", 0)]
        [TestCase("こんにち", 0)]
        [TestCase("本日", 0)]
        [TestCase("ほんじつ", 0)]
        [TestCase("明日", 1)]
        [TestCase("あした", 1)]
        [TestCase("あす", 1)]
        [TestCase("みょうにち", 1)]
        [TestCase("明後日", 2)]
        [TestCase("あさって", 2)]
        [TestCase("みょうごにち", 2)]
        [TestCase("明々後日", 3)]
        [TestCase("明明後日", 3)]
        [TestCase("しあさって", 3)]
        [TestCase("弥明後日", 4)]
        [TestCase("弥の明後日", 4)]
        [TestCase("やのあさって", 4)]
        [TestCase("やなあさって", 4)]
        public void GetTargetDayTest(string targetDay, int targetIndex)
        {
            // Arrange
            var mension = string.Format("{0}の天気を教えてください！", targetDay);
            var logic = new ForecastDayLogic();

            // Act
            var record = logic.GetTargetDay(mension);

            // Assert
            Assert.IsNotNull(record);
            Assert.AreEqual(targetDay, record.Keyword);
            Assert.AreEqual(targetIndex, record.TargetIndex);
        }

        [TestCase("今日", 0)]
        public void GetNoTargetDayTest(string targetDay, int targetIndex)
        {
            // Arrange
            var logic = new ForecastDayLogic();

            // Act
            var record = logic.GetTargetDay("天気を教えてください！");

            // Assert
            Assert.IsNotNull(record);
            Assert.AreEqual(targetDay, record.Keyword);
            Assert.AreEqual(targetIndex, record.TargetIndex);
        }

    }
}
