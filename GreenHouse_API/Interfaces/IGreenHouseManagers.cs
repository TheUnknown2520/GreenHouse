using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;

namespace GreenHouse_API.Interfaces
{
    interface IGreenHouseManagers
    {
        public IEnumerable<Klima> GetAll();

        public Klima Get(DateTime date);

        bool Create(Klima klima);

        public Klima GetLatest();

        public List<Klima> GetLast24Hours();

    }
}
