using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcThermometer.Models;

namespace MvcThermometer.Data
{
    public class MvcThermometerContext : DbContext
    {
        public MvcThermometerContext(DbContextOptions<MvcThermometerContext> options)
           : base(options)
        {
        }

        public DbSet<Thermometer> Thermometer { get; set; }
    }
}
