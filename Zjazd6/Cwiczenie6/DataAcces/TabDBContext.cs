using cwiczenie6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie6.DataAcces
{
    public class TabDBContext : DbContext
    {
        protected TabDBContext()
        {
        }

        public TabDBContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Doctor> Doctors { get; set; } 
    }
}
