using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreenHouse_API.Managers;
using ModelLib;
using System.Linq;
using System;
using System.Collections.Generic;

namespace GreenHouseTest
{
    [TestClass]
    public class UnitTest1
    {
        public List<Klima> Klimas = new List<Klima>();
        private GreenHouseManager _mgr;

        [TestInitialize]
        public void SetUp()
        {
            _mgr = new GreenHouseManager();
            Klimas = _mgr.GetAll();
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
            Klima ecpectedKlima = new Klima(System.DateTime.Now, 11, 200);

            Klimas.Add(ecpectedKlima);
            
             Klima actualAththe = _mgr.Get(ecpectedKlima.Date);
                
            Assert.AreEqual(ecpectedKlima, actualAththe);

        }



        [TestMethod]

        //[DataRow(20, 96, 2911  )]
        //[DataRow(21, 100, )]
        public void CreateTest()
        {
            var originalListLength = _mgr.GetAll().Count();
            var CreateClima = new Klima( DateTime.Now, 23, 80);

            var result = _mgr.Create(CreateClima);
            Assert.IsTrue(result);
            
            //tjekker at list størelsen er blevet støre 
            var newListLength = _mgr.GetAll().Count();
            Assert.AreEqual(originalListLength + 1, newListLength);
        }

        [TestMethod]
        public void GetLast24HoursList()
        {
            List<Klima> døgList = new List<Klima>();
            døgList = _mgr.GetLast24Hours();
            Assert.AreEqual(2, døgList.Count);

            Klima klima1 = new Klima(DateTime.Now.AddHours(-23), 24, 2088);
            _mgr.GetAll().Add(klima1);
            døgList = _mgr.GetLast24Hours();
            Assert.AreEqual(3, døgList.Count, 0.001);
            Cleanup();

            Klima klima2 = new Klima(DateTime.Now.AddHours(-24), 24, 2088);
            _mgr.GetAll().Add(klima2);
            døgList = _mgr.GetLast24Hours();
            Assert.AreEqual(2, døgList.Count, 0.001);
            Cleanup();

            Klima klima3 = new Klima(DateTime.Now.AddHours(-25), 24, 2088);
            _mgr.GetAll().Add(klima3);
            døgList = _mgr.GetLast24Hours();
            Assert.AreEqual(2, døgList.Count, 0.001);

        }
    }
}
