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
    public class ReceivingLogLogicTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void GetLatestReceivingLogTest()
        {
            // Arrange
            var logic = new ReceivingLogLogic();

            // Act
            var record = logic.GetLatestReceivingLog();

            // Assert
            // Assert.IsNotNull(record); // 結果はテーブルの状況によるのでよくない
            Assert.Fail();
        }
    }
}
