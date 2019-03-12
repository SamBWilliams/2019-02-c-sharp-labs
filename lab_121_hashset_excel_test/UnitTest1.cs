using NUnit.Framework;
using lab_121_hash_set_to_excel;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
         * Start a stopwatch
         * Pass 3 numbers to array
         * Double numbers and pass to a Linked list
         * Doubke numbers and pass to hash set
         * Add 15, treble numbers and pass to dictionary
         * Stop the stopwatch
         * Return the test as a custom object containing-
         *      ElapsedTime (int, in milliseconds)
         *      First number
         *      Second number
         *      third number
         * Test passes if stopwatch time less than time passed in (4th variable) (set to 10 secs)
         * Not part of the test
         * Output all values to .csv text file and append to existing file
         *      DATETIME stamp
         *      Input 4 params
         *      Output 4 params
         * Finally launch excel to read this file using process.start
         * 
         */
        [TestCase(10, 20, 30, 10000)]
        public void HashSetExcelTest1(int a, int b, int c, int d)
        {
            var instance = new HashSetToExcel();
            Assert.LessOrEqual(instance.HasSetExcelTest(a, b, c).Etime, d);
        }
    }
}