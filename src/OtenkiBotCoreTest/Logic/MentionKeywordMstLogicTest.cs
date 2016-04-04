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
    public class MentionKeywordMstLogicTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [TestCase("あいうえお", MentionTypeMst.MentionType.Unknown)]
        public void GetMentionTypeIdTest(string mention, MentionTypeMst.MentionType id)
        {
            // Arrange
            var logic = new MentionKeywordMstLogic();

            // Act
            var actual = logic.GetMentionTypeId(mention);

            // Assert
            Assert.AreEqual((int)id, actual);
        }
    }
}
