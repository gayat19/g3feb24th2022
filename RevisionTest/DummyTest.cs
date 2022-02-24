using NUnit.Framework;
using RevisionApplication.Services;
using System;

namespace RevisionTest
{
    public class DummyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void TestCheckData(bool exp)
        {
            //Arrange
            DummyService service = new DummyService();

            //Act
            var result = service.CheckData();

            //Assert
            Assert.AreEqual(exp,result);
        }

        [Test]
        [TestCase(100)]
        [TestCase(1000)]
        public void TestGetNumber(int num)
        {
            //Arrange
            DummyService service = new DummyService();

            //Act
            var result = service.GetNumber();

            //Assert
            Assert.AreEqual(num, result);
        }

        [Test]
        [TestCase(100,90,110)]
        [TestCase(111,110,150)]
        public void TestGetNumberWithRange(int exp,int min,int max)
        {
            //Arrange
            DummyService service = new DummyService();

            //Act
            var result = service.TakeRangeAndGetNumber(min, max);

            //Assert
            Assert.AreEqual(exp, result);
        }

        [Test]
        [TestCase(100, 90)]
        [TestCase(111, 0)]
        public void Test( int num1, int num2)
        {
            //Arrange
            DummyService service = new DummyService();

            //Act
            //var result = service.ExceptionCheck(num1, num2);

            //Assert
            
        }

    }
}