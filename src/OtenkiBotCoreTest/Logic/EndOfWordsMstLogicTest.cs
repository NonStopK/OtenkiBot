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
    public class EndOfWordsMstLogicTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void GetRandomOneTest()
        {
            // Arrange
            var logic = new EndOfWordsMstLogic();

            // Act
            var s = logic.GetRandomOne();

            // Assert
            Assert.IsNotEmpty(s);
        }
    }
}
