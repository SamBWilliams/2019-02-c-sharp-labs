using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_112_collections;
using lab_113_arraylist;

namespace labs_test
{
    [TestClass]
    public class LabsTest
    {
        [TestMethod]
        public void Lab112CollectionsTest()
        {
            //arrange
            var expected01 = -10;
            var expected02 = -10;
            var instanceLab112Col = new Collections();

            //act
            var actual01 = instanceLab112Col.col20minLab(10, 20, 30);
            var actual02 = instanceLab112Col.col20minLab(11, 12, 13);

            //assert
            Assert.AreEqual(expected01, actual01);
            Assert.AreEqual(expected02, actual02);
           
        }

        [TestMethod]
        public void Lab113ArrayListTest()
        {
            var expected = -10;
            var instanceLab113 = new arrayList();

            var actual = instanceLab113.arrayListMethod(10, 20, 30, 40);

            Assert.AreEqual(expected, actual);
        }
    }
}
