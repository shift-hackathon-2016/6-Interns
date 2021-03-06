﻿using RuffLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Data.Context
{
    public class RuffLifeInitializer: System.Data.Entity.DropCreateDatabaseAlways<RuffLifeContext>
    {
        protected override void Seed(RuffLifeContext context)
        {
            var owners = new List<Owner>
            {
                new Owner { Username = "Andrea", Location = "Split", Address = "Fra Luje Maruna 5", ContactNumber = "095", Email = "andrea@dump.hr" },
                new Owner { Username = "Mirko", Location = "Kaštela", Address = "Mirkova adresa", ContactNumber = "095", Email = "mirko@dump.hr" },
                new Owner { Username = "Nikola", Location = "Split", Address = "Nikolina adresa", ContactNumber = "095", Email = "nikola@dump.hr" }
            };
            owners.ForEach(x => context.Owners.Add(x));
            context.SaveChanges();

            var dogs = new List<Dog>
            {
                new Dog { Name = "Dota", Breed = "Jack Russell", Age = "7", Gender = 'F', Owner = context.Owners.FirstOrDefault(x => x.Username == "Andrea") },
                new Dog { Name = "Alba", Breed = "Jack Russell", Age = "2", Gender = 'F', Owner = context.Owners.FirstOrDefault(x => x.Username == "Nikola") },
                new Dog { Name = "Vau", Breed = "Labrador", Age = "5", Gender = 'M', Owner = context.Owners.FirstOrDefault(x => x.Username == "Mirko") }
            };
            dogs.ForEach(x => context.Dogs.Add(x));
            context.SaveChanges();

            var walkers = new List<Walker>
            {
                new Walker { Username = "Izabela", Location = "Split", Email = "izabela@dump.hr", CostPerHourInHRK = 50, ContactNumber = "095" },
                new Walker { Username = "Josipa", Location = "Kaštela", Email = "josipa@dump.hr", CostPerHourInHRK = 60, ContactNumber = "095" },
                new Walker { Username = "Ante", Location = "Zagreb", Email = "ante@mail.com", CostPerHourInHRK = 70, ContactNumber = "095" }
            };
            walkers.ForEach(x => context.Walkers.Add(x));
            context.SaveChanges();

            var walks = new List<Walk>
            {
                new Walk { StartTime = new DateTime(2016, 5, 31, 8, 0, 0), EndTime = new DateTime(2016, 5, 31, 9, 0, 0), Location = "Lokacija1", Price = 50, Walker = context.Walkers.FirstOrDefault(x => x.Username == "Izabela") },
                new Walk { StartTime = new DateTime(2016, 5, 31, 10, 0, 0), EndTime = new DateTime(2016, 5, 31, 12, 0, 0), Location = "Lokacija2", Price = 60, Walker = context.Walkers.FirstOrDefault(x => x.Username == "Josipa") },
                new Walk { StartTime = new DateTime(2016, 5, 31, 20, 0, 0), EndTime = new DateTime(2016, 5, 31, 23, 0, 0), Location = "Lokacija3", Price = 70, Walker = context.Walkers.FirstOrDefault(x => x.Username == "Izabela") }
            };
            walks.ForEach(x => context.Walks.Add(x));
            context.SaveChanges();

            
        }
    }
}
