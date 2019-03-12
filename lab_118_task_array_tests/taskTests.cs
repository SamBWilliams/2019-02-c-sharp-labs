using NUnit.Framework;
using lab_118_array_of_tests;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //any set up code eg generate fresh database
            //any initialization before run any tests
        }

        [TestCase(1000, 7000)]
        [TestCase(10000, 60000)]
        [TestCase(1000, 500)]
        public void TestFileSyncroReadWrite(int NumberOfFiles, long maxTime)
        {

            var instance = new FileOperationSynchro();

            long timeTaken = instance.FileReadWrite(NumberOfFiles);
           // string output = instance.FileReadWrite(NumberOfFiles);
            System.Console.WriteLine($"Time taken: {timeTaken} milliseconds");


            //Assert.IsInstanceOf<string>(output);
            Assert.Less(timeTaken, maxTime);
        }
    }
}