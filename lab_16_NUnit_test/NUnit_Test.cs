using NUnit.Framework;
using lab_16_NUnit_XUnit_tests;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void lab_16_NUnit_test_01()
        {
            //arrang
            var expected = 36.0;
            var instance02 = new TestMeNow();

            //act
            var actual = instance02.TestThisMethodWorks(2, 3, 2);

            //assert
            Assert.AreEqual(expected, actual);
           
        }


        [TestCase(2,3,2,36)]
        [TestCase(2, 3, 2, 37)]
        public void lab_16_NUnit_test_02(double x, double y, double p, double expected)
        {
            //arrang
            //var expected = 36.0;
            var instance03 = new TestMeNow();

            //act
            var actual = instance03.TestThisMethodWorks(2, 3, 2);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}