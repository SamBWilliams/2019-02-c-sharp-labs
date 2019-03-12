using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_16_NUnit_XUnit_tests;

namespace lab_16_MSTest
{
    [TestClass]
    public class lab_16_test_class
    {

        [TestInitialize]
        public void Initialize()
        {
            System.Console.WriteLine("Initializing Tests");
        }

        [TestMethod]
        public void TestLab16UsingMSTest()
        {
            //arrange
            var expected = 216.0;
            var instance01 = new TestMeNow();

            //act
            var actual = instance01.TestThisMethodWorks(2, 3, 3);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCleanup]
        public void Cleanup()
        {
            System.Console.WriteLine("Cleaning up after tests have run");
        }
    }
}
