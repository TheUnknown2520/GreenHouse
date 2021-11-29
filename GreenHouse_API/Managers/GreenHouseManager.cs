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
                new Klima(23, 90, 2411),
                new Klima(20, 90, 2410),
                new Klima(18, 90, 2412)
            };
        }

        public List<Klima> GetAll()
        {
            return _klimas;
        }

        public Klima Get(int date)
        {
            var klima = _klimas.Find(k => k.Date == date);
            if (klima == null) throw new KeyNotFoundException("der er ikke nogle målinger på denne dato");
            return klima;
        }

        public bool Create(Klima klima)
        {
            _klimas.Add(klima);
            return true;
        }

        public void TestCleanUp()
        {
            _klimas = new List<Klima>()
            {
                new Klima(23, 89, 2411),
                new Klima(20, 98, 2410),
                new Klima(18, 90, 2412)
            };
        }
    }
}
