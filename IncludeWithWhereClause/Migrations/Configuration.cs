namespace IncludeWithWhereClause.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IncludeWithWhereClause.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IncludeWithWhereClause.EntityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(
                new Customer() { Name = "Customer_1" },
            new Customer() { Name = "Customer_2" },
            new Customer() { Name = "Customer_3" }
            );

            context.Invoices.AddOrUpdate(
                 new Invoice() { Date = new DateTime(2018, 1, 5), CustomerID = 1 },
            new Invoice() { Date = new DateTime(2018, 5, 3), CustomerID = 1 },
            new Invoice() { Date = DateTime.Now.AddDays(-5), CustomerID = 1 },
            new Invoice() { Date = DateTime.Now.AddDays(-3), CustomerID = 1 },
            new Invoice() { Date = new DateTime(2018, 4, 15), CustomerID = 2 },
            new Invoice() { Date = new DateTime(2018, 2, 20), CustomerID = 3 },
            new Invoice() { Date = new DateTime(2018, 5, 22), CustomerID = 3 },
            new Invoice() { Date = new DateTime(2018, 5, 23), CustomerID = 3 }
            );
            context.SaveChanges();

            context.Customers.AddOrUpdate(
                new Customer
                {
                    Name = "David Morrow",
                    Invoices = new System.Collections.Generic.List<Invoice>
                {
                    new Invoice { Date = new DateTime(1973, 3, 3) },
                    new Invoice { Date = new DateTime(1984, 7, 27) },
                    new Invoice { Date = new DateTime(1992, 10, 13) },
                    new Invoice { Date = new DateTime(2006, 2, 5) },
                    new Invoice { Date = new DateTime(2017, 5, 18) }
                }
                });

                context.SaveChanges();

        }
    }
}
