namespace _09_PerRouteMHOwnershipSample.Migrations
{
    using _09_PerRouteMHOwnershipSample.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_09_PerRouteMHOwnershipSample.Models.MyShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_09_PerRouteMHOwnershipSample.Models.MyShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<string> salts = new List<string>();
            for (int i = 0; i < 5; i++) {
                salts.Add(CryptoUtil.GenerateSalt());
			}

            context.Customers.AddOrUpdate(
                c => c.Name,
                new Customer {
                    Name = "Tugberk",
                    Surname = "Ugurlu",
                    Email = "tugberk@example.com",
                    Salt = salts[1],
                    HashedPassword = CryptoUtil.EncryptPassword("tugberk", salts[1])
                },
                new Customer {
                    Name = "Bill",
                    Surname = "Gates",
                    Email = "bill@example.com",
                    Salt = salts[2],
                    HashedPassword = CryptoUtil.EncryptPassword("bill", salts[2])
                },
                new Customer {
                    Name = "Steve",
                    Surname = "Ballmer",
                    Email = "steve@example.com",
                    Salt = salts[3],
                    HashedPassword = CryptoUtil.EncryptPassword("steve", salts[3])
                }
            );

            context.Orders.AddOrUpdate(
                c => c.ProductName,
                new Order { CustomerKey = 1, ProductName = "Surface", Price = 499.99M, PurchasedOn = DateTime.Now },
                new Order { CustomerKey = 1, ProductName = "Nokia Lumia 920", Price = 699.99M, PurchasedOn = DateTime.Now },
                new Order { CustomerKey = 1, ProductName = "Windows 8 Pro", Price = 800.00M, PurchasedOn = DateTime.Now },
                new Order { CustomerKey = 2, ProductName = "SUV Car", Price = 350000.00M, PurchasedOn = DateTime.Now },
                new Order { CustomerKey = 2, ProductName = "Laptop", Price = 1225.98M, PurchasedOn = DateTime.Now },
                new Order { CustomerKey = 3, ProductName = "Windows Server 2012 (Enterprise Edition)", Price = 6000.00M, PurchasedOn = DateTime.Now }
            );
        }
    }
}