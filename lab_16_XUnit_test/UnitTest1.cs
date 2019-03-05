using System;
using Xunit;
using lab_16_NUnit_XUnit_tests;

namespace lab_16_XUnit_test
{
    public class lab_16_XUnit_tests
    {
        [Fact]
        public void lab_16_XUnit_test_01()
        {
            //arrang
            var expected = 9765625.0;
            var instance03 = new TestMeNow();

            //act
            var actual = instance03.TestThisMethodWorks(5, 5, 5);

            //assert
            Assert.Equal(expected, actual);
            
        }
    }
}
