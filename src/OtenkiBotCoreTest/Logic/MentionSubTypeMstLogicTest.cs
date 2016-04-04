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
    public class MentionSubTypeMstLogicTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void GetTest()
        {
            // Arrange
            var logic = new MentionSubTypeMstLogic();
            var dt = new DateTime(2016,1,1);

            // Act
            var s = logic.Get(11, dt);

            // Assert
            // TODO: 
        }
    }
}
