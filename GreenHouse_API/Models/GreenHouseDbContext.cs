using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLib;

namespace GreenHouse_API.Models
{
    public class GreenHouseDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder option)
        //{
        //    option.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=GreenHouseDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        //}

        public GreenHouseDbContext(DbContextOptions<GreenHouseDbContext> options) : base(options)
        {

        }


        public DbSet<Klima> Klimas { get; set; }


    }
}
