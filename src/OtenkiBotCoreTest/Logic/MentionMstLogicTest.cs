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
    public class MentionMstLogicTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void GetRandomSoliloquyTest()
        {
            // Arrange
            var logic = new MentionMstLogic();

            // Act
            var s = logic.GetRandomSoliloquy();

            // Assert
            Assert.IsNotEmpty(s);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        public void GetRandomOneTest(int id)
        {
            // Arrange
            var logic = new MentionMstLogic();

            // Act
            var s = logic.GetRandomOne(id, (int)MentionSubTypeMst.MentionSubType.Unknown);

            // Assert
            Assert.IsNotEmpty(s);
        }
    }
}
