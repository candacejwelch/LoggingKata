using NUnit.Framework;

namespace LoggingKata.Test
{
    [TestFixture]
    public class TacoParserTestFixture
    {
        [Test]
        public void ShouldParseLine()
        {
            //arrange
            var tacoParser = new TacoParser();

            var lessThanThree = "12334, 12333";
            var longNotNumber = "abc, 1234, Testing";
            var latNotNumber = "abc, 123, Testing";

            //act
            var lessThanThreeValue = tacoParser.ParseTacos(lessThanThree);
            var longNotNumberValue = tacoParser.ParseTacos(longNotNumber);
            var latNotNumberValue = tacoParser.ParseTacos(latNotNumber);


            //asert
            Assert.Null(lessThanThreeValue, "lest than 3 should not parse");
            Assert.Null(longNotNumberValue, "long not number should not parse");
            Assert.Null(latNotNumberValue, "lat not number should not parse");


        }

        [Test]
        public void ShouldNotParseLine()
        {
            //arrange
            var tacoParser = new TacoParser();
            var correctString = "123.04, 456.07, TestingName";

            //act
            var correctStringValue = tacoParser.ParseTacos(correctString);

            //asert
            Assert.NotNull(correctStringValue, "Should pass");


        }
    }
}
