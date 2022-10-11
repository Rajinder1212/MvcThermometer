using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcThermometer.Data;


namespace MvcThermometer.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcThermometerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcThermometerContext>>()))
            {
                // Look for any movies.
                if (context.Thermometer.Any())
                {
                    return;   // DB has been seeded
                }

                context.Thermometer.AddRange(
                    new Thermometer
                    {
                        Features = "Temperature sensor",
                        Celcious = 37.5,
                        Fahrenheit = 99.5,
                        Price = 41,
                        Type = "Digital ",
                    },


                    new Thermometer
                    {
                        Features = " Read from scale",
                        Celcious = -35,
                        Fahrenheit = 673,
                        Price = 55,
                        Type = "Mercury ",
                    },

                    new Thermometer
                    {
                        Features = "Read temperature instantly  ",
                        Celcious = 65,
                        Fahrenheit = 180,
                        Price = 70,
                        Type = "Read-food ",
                    },

                    new Thermometer
                    {
                        Features = " self-reported tool ",
                        Celcious = 58,
                        Fahrenheit = 150,
                        Price = 32,
                        Type = "Patient Distress",

                    },

                     new Thermometer
                     {
                         Features = " ranging alcohol  ",
                         Celcious = 78,
                         Fahrenheit = 110,
                         Price = 22,
                         Type = "Alcoholic ",
                     },
                     new Thermometer
                     {
                         Features = " cooking fork and food thermometer  ",
                         Celcious = 18,
                         Fahrenheit = 104,
                         Price = 16,
                         Type = "Fork ",
                     }
                );
                context.SaveChanges();
            }
        }
    }
}