using NUnit.Framework;
using OtenkiBotCore.Entity;
using OtenkiBotCore.Logic;
using OtenkiBotCore.TweetController;

namespace OtenkiBotCoreTest.TweetController
{
    [TestFixture]
    public class ReplyCreatorFactoryTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void CreateReplyValidTest()
        {
            // Arrange
            var area = new ForecastAreaRelationship();

            // Act
            var creator = new ReplyCreatorFactory().Create(area);

            // Assert
            Assert.AreEqual(creator.GetType(), typeof(ForecastReplyCreator));
        }

        [Test]
        public void CreateReplyInvalidTest()
        {
            // Arrange

            // Act
            var creator = new ReplyCreatorFactory().Create(null);

            // Assert
            Assert.AreEqual(creator.GetType(), typeof(MeaninglessReplyCreator));
        }
    }
}
