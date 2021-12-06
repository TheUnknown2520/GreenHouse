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

                new Klima(System.DateTime.Now, 23, 2411),
                new Klima(System.DateTime.Now, 23, 2411),
                new Klima(DateTime.Now, 23, 2411),

            };
        }

        public List<Klima> GetAll()
        {
            return _klimas;
        }

        public Klima Get(DateTime date)
        {
            var klima = _klimas.Find(k => k.Date == date);
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

                new Klima(System.DateTime.Now, 23, 2411),
                new Klima(System.DateTime.Now, 23, 2411),
                new Klima(DateTime.Now, 23, 2411),

            };
        }
    }
}
