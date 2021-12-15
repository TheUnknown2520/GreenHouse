﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GreenHouse_API.Interfaces;
using GreenHouse_API.Models;
using ModelLib;

namespace GreenHouse_API.Managers
{
    public class GreenHouseManagerDB : IGreenHouseManagers
    {
        private readonly GreenHouseDbContext dbContext;
        public List<Klima> _klima = new List<Klima>();
        public GreenHouseManagerDB(GreenHouseDbContext DbContext)
        {
            DbContext = dbContext;
            _klima = GetAll().ToList();
        }
        public IEnumerable<Klima> GetAll()
        {
            return dbContext.Klimas.ToList();
        }

        public Klima Get(DateTime date)
        {
            foreach (var Obj in _klima)
            {
                if (Obj.Date == date)
                {
                    return Obj;
                }
            }

            return null;
        }

        public bool Create(Klima klima)
        {
            try
            {
                dbContext.Klimas.Add(klima);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Klima GetLatest()
        {
            int test = _klima.Count();
            return _klima[test - 1];
        }

        public List<Klima> GetLast24Hours()
        {
            DateTime dateNow = DateTime.Now;
            DateTime h = dateNow.AddHours(-24);
            List<Klima> døgnList = new List<Klima>();

            foreach (var k in _klima)
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
