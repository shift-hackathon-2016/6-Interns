using System.Collections.Generic;
using RuffLife.Data.Models;

namespace RuffLife.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RuffLife.Data.Context.RuffLifeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RuffLife.Data.Context.RuffLifeContext context)
        {
            var owners = new List<Owner>
            {
                new Owner { Username = "Andrea", Location = "Split", Address = "Fra Luje Maruna 5", ContactNumber = "095", Email = "andrea@dump.hr" },
                new Owner { Username = "Mirko", Location = "Ka�tela", Address = "Mirkova adresa", ContactNumber = "095", Email = "mirko@dump.hr" },
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
                new Walker { Username = "Josipa", Location = "Ka�tela", Email = "josipa@dump.hr", CostPerHourInHRK = 60, ContactNumber = "095" },
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

            var reviewForWalkers = new List<ReviewForWalker>
            {
                new ReviewForWalker { Grade = 5, Review = "Super", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Izabela"), Owner = context.Owners.FirstOrDefault(x => x.Username == "Andrea") },
                new ReviewForWalker { Grade = 4, Review = "Vrlo dobro", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Josipa"), Owner = context.Owners.FirstOrDefault(x => x.Username == "Mirko") },
                new ReviewForWalker { Grade = 3, Review = "OK", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Ante"), Owner = context.Owners.FirstOrDefault(x => x.Username == "Nikola") }
            };
            reviewForWalkers.ForEach(x => context.ReviewsForWalkers.Add(x));
            context.SaveChanges();

            var reviewForDogs = new List<ReviewForDog>
            {
                new ReviewForDog { Grade = 5, Review = "Super", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Izabela"), Dog = context.Dogs.FirstOrDefault(x => x.Name == "Dota") },
                new ReviewForDog { Grade = 5, Review = "Super", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Josipa"), Dog = context.Dogs.FirstOrDefault(x => x.Name == "Alba") },
                new ReviewForDog { Grade = 4, Review = "Vrlo dobro", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Ante"), Dog = context.Dogs.FirstOrDefault(x => x.Name == "Vau") }
            };
            reviewForDogs.ForEach(x => context.ReviewsForDogs.Add(x));
            context.SaveChanges();
        }

        //var owners = new List<Owner>
        //{
        //    new Owner { Username = "Andrea", Location = "Split", Address = "Fra Luje Maruna 5", ContactNumber = "095", Email = "andrea@dump.hr" },
        //    new Owner { Username = "Mirko", Location = "Ka�tela", Address = "Mirkova adresa", ContactNumber = "095", Email = "mirko@dump.hr" },
        //    new Owner { Username = "Nikola", Location = "Split", Address = "Nikolina adresa", ContactNumber = "095", Email = "nikola@dump.hr" }
        //};
        //owners.ForEach(x => context.Owners.AddOrUpdate(o => o.Username, x));
        //context.SaveChanges();

        //var dogs = new List<Dog>
        //{
        //    new Dog { Name = "Dota", Breed = "Jack Russell", Age = "7", Gender = 'F', Owner = context.Owners.FirstOrDefault(x => x.Username == "Andrea")},
        //    new Dog { Name = "Alba", Breed = "Jack Russell", Age = "2", Gender = 'F', Owner = context.Owners.FirstOrDefault(x => x.Username == "Nikola") },
        //    new Dog { Name = "Vau", Breed = "Labrador", Age = "5", Gender = 'M', Owner = context.Owners.FirstOrDefault(x => x.Username == "Mirko") }
        //};
        //dogs.ForEach(x => context.Dogs.AddOrUpdate(d => new { d.Name, d.Owner.Id }, x));
        //context.SaveChanges();

        //var walkers = new List<Walker>
        //{
        //    new Walker { Username = "Izabela", Location = "Split", Email = "izabela@dump.hr", CostPerHourInHRK = 50, ContactNumber = "095" },
        //    new Walker { Username = "Josipa", Location = "Ka�tela", Email = "josipa@dump.hr", CostPerHourInHRK = 60, ContactNumber = "095" },
        //    new Walker { Username = "Ante", Location = "Zagreb", Email = "ante@mail.com", CostPerHourInHRK = 70, ContactNumber = "095" }
        //};
        //walkers.ForEach(x => context.Walkers.AddOrUpdate(w => w.Username, x));
        //context.SaveChanges();

        //var walks = new List<Walk>
        //{
        //    new Walk { StartTime = new DateTime(2016, 5, 31, 8, 0, 0), EndTime = new DateTime(2016, 5, 31, 9, 0, 0), Location = "Lokacija1", Price = 50, Walker = context.Walkers.FirstOrDefault(x => x.Username == "Izabela") },
        //    new Walk { StartTime = new DateTime(2016, 5, 31, 10, 0, 0), EndTime = new DateTime(2016, 5, 31, 12, 0, 0), Location = "Lokacija2", Price = 60, Walker = context.Walkers.FirstOrDefault(x => x.Username == "Josipa") },
        //    new Walk { StartTime = new DateTime(2016, 5, 31, 20, 0, 0), EndTime = new DateTime(2016, 5, 31, 23, 0, 0), Location = "Lokacija3", Price = 70, Walker = context.Walkers.FirstOrDefault(x => x.Username == "Izabela") }
        //};
        //walks.ForEach(x => context.Walks.AddOrUpdate(w => new { w.Walker.Id, w.StartTime }, x));
        //context.SaveChanges();

        //var reviewForWalkers = new List<ReviewForWalker>
        //{
        //    new ReviewForWalker { Grade = 5, Review = "Super", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Izabela"), Owner = context.Owners.FirstOrDefault(x => x.Username == "Andrea") },
        //    new ReviewForWalker { Grade = 4, Review = "Vrlo dobro", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Josipa"), Owner = context.Owners.FirstOrDefault(x => x.Username == "Mirko") },
        //    new ReviewForWalker { Grade = 3, Review = "OK", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Ante"), Owner = context.Owners.FirstOrDefault(x => x.Username == "Nikola") }
        //};
        //reviewForWalkers.ForEach(x => context.ReviewsForWalkers.AddOrUpdate(rw => new { rw.Walker, rw.Owner }, x));
        //context.SaveChanges();

        //var reviewForDogs = new List<ReviewForDog>
        //{
        //    new ReviewForDog { Grade = 5, Review = "Super", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Izabela"), Dog = context.Dogs.FirstOrDefault(x => x.Name == "Dota") },
        //    new ReviewForDog { Grade = 5, Review = "Super", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Josipa"), Dog = context.Dogs.FirstOrDefault(x => x.Name == "Alba") },
        //    new ReviewForDog { Grade = 4, Review = "Vrlo dobro", Walker = context.Walkers.FirstOrDefault(x => x.Username == "Ante"), Dog = context.Dogs.FirstOrDefault(x => x.Name == "Vau") }
        //};
        //reviewForDogs.ForEach(x => context.ReviewsForDogs.AddOrUpdate(rd => new { rd.Dog, rd.Walker }, x));
        //context.SaveChanges();
    }
}
