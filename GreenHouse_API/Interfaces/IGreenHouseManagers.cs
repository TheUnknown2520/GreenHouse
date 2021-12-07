using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;

namespace GreenHouse_API.Interfaces
{
    interface IGreenHouseManagers
    {
        public List<Klima> GetAll();

        public Klima Get(DateTime date);

        Klima Create(Klima klima);

        public Klima GetLatest();

        public List<Klima> GetLast24Hours();

    }
}
