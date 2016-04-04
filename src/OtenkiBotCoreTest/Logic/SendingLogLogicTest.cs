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
    public class SendingLogLogicTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [TestCase("")]
        public void SetSendingLogTest(string s)
        {
            // Arrange
            var logic = new SendingLogLogic();

            // Act
            //logic.SetSendingLog(0, s);

            // Assert
            // きちんと書き込まれたか確認する。
            Assert.Fail();
        }

        [TestCase(10)]
        public void IsPassedTest(double minutes)
        {
            // Arrange
            var logic = new SendingLogLogic();

            // Act
            var isPassed = logic.IsPassed(minutes);

            // Assert
            // きちんと判定されたか確認する。
            Assert.Fail();
        }

    }
}
