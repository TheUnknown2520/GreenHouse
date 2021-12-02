using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreenHouse_API.Managers;
using ModelLib;
using System.Linq;
using System;

namespace GreenHouseTest
{
    [TestClass]
    public class UnitTest1
    {
        private GreenHouseManager _mgr;

        [TestInitialize]
        public void SetUp()
        {
            _mgr = new GreenHouseManager();
            _mgr.TestCleanUp();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mgr.TestCleanUp();
        }

        [TestMethod]
        public void GetAllTest()
        {

            int expectedCount = 3;
            int ActualCount = _mgr.GetAll().Count();
            Assert.AreEqual(expectedCount, ActualCount);

        }



        [TestMethod]
        public void GetTempByDate()
        {


            Klima ecpectedKlima = new Klima(23, 2411, DateTime.Now);
            Klima actualAththe = _mgr.Get(DateTime.Now);
            Assert.AreEqual(ecpectedKlima, actualAththe);

        }



        [TestMethod]
        [DataRow(20, 96, 2911  )]
        [DataRow(21, 100, 3011)]
        public void CreateTest(int temperature, int humidity, int date)
        {
            var originalListLength = _mgr.GetAll().Count();
            var CreateClima = new Klima(temperature, humidity, date);

            var result = _mgr.Create(CreateClima);
            Assert.IsTrue(result);

            //tjekker at list størelsen er blevet støre 
            var newListLength = _mgr.GetAll().Count();
            Assert.AreEqual(originalListLength + 1, newListLength);
        }


    }
}
