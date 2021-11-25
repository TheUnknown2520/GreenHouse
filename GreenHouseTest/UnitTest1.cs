using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreenHouse_API.Managers;
using ModelLib;
using System.Linq;

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
            Klima ecpectedKlima = new Klima(23, 2411);

            Klima actualAththe = _mgr.Get(2411);

            Assert.AreEqual(ecpectedKlima, actualAththe);
        }


    }
}
