using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;
using GreenHouse_API.Interfaces;

namespace GreenHouse_API.Managers
{
    public class GreenHouseManager : IGreenHouseManagers 
    {
        private static List<Klima> _klimas;

        public GreenHouseManager()
        {
            _klimas ??= new List<Klima>()
            {

                new Klima(System.DateTime.Now, 24, 80),
                new Klima(System.DateTime.Now.AddHours(-28), 23, 30),
                new Klima(DateTime.Now, 19, 40),
                //new Klima(DateTime.Now.AddHours(-22), 19, 40),

            };
        }

        public List<Klima> GetAll()
        {
            return _klimas;
        }

        public Klima Get(DateTime date)
        {
            var klima = _klimas.Find(k => CheckDate(k.Date, date));
            if (klima == null) throw new KeyNotFoundException("der er ikke nogle målinger på denne dato");
            return klima;
        }

        public Klima GetLatest()
        {
            int test = _klimas.Count();
            return _klimas[test - 1];
        }

        public Klima Create(Klima klima)
        {
            _klimas.Add(klima);
            return klima;
        }


        public void TestCleanUp()
        {
            _klimas = new List<Klima>()
            {

                new Klima(System.DateTime.Now, 24, 80),
                new Klima(System.DateTime.Now.AddHours(-28), 23, 30),
                new Klima(DateTime.Now, 19, 40),

            };
        }

        private bool CheckDate(DateTime actual1, DateTime date2)
        {
            if (actual1.Year == date2.Year && actual1.Month == date2.Month && actual1.Day == date2.Day && actual1.Hour == date2.Hour)
            {
                return true;
            }

            return false;
        }

        public List<Klima> GetLast24Hours()
        {
            DateTime dateNow = DateTime.Now;
            DateTime h = dateNow.AddHours(-24);
            List<Klima> døgnList = new List<Klima>();

            foreach (var k in GetAll())
            {
                if (k.Date > h && k.Date <= dateNow)
                {
                    døgnList.Add(k);
                }
            }

            return døgnList;
        }
    }
}
