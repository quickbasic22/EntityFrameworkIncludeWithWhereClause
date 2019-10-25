// @nuget: EntityFramework
// @nuget: Z.EntityFramework.Extensions

using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using IncludeWithWhereClause;
using Z.EntityFramework.Plus;

public class Program
{
    public static void Main()
    {
        IncludeWhere();
        ProjectionQuery();
        IncludeFilterQuery();
               
            Console.ReadKey();
  
    }

    private static void IncludeWhere()
    {
        using (var context = new EntityContext())
        {
            var fromDate = DateTime.Now.AddDays(-7);

            var customer = context.Customers.Where(c => c.CustomerID == 3)
                .Include(c => c.Invoices)
                .Where(c => c.Invoices.Any(i => i.Date >= fromDate))
                .FirstOrDefault();

            Console.WriteLine(customer.Name + " " + customer.CustomerID + "\n\r");
            foreach (var invoice in customer.Invoices.ToList())
            {
                Console.WriteLine(invoice.InvoiceID + " " + invoice.Customer.Name + " " + invoice.Date + "\r\n");
            }

        }
    }

    private static void ProjectionQuery()
    {
        using (var context = new EntityContext())
        {
            var fromDate = DateTime.Now.AddDays(-7);

            var customer = context.Customers.Where(c => c.CustomerID == 3)
                .Where(c => c.Invoices.Any(i => i.Date >= fromDate))
                .Select(c => new
                {
                    c,
                    Invoices = c.Invoices.Where(i => i.Date >= fromDate)
                })
                .FirstOrDefault();

            Console.WriteLine(customer.c.Name + " " + customer.c.CustomerID + "\n\r");
            foreach (var invoice in customer.Invoices.ToList())
            {
                Console.WriteLine(invoice.InvoiceID + " " + invoice.Customer.Name + " " + invoice.Date + "\r\n");
            }

        }
    }

    private static void IncludeFilterQuery()
    {
        using (var context = new EntityContext())
        {
            var fromDate = DateTime.Now.AddDays(-7);

            var customer = context.Customers.Where(c => c.CustomerID == 3)
                    .IncludeFilter(c => c.Invoices.Where(i => i.Date >= fromDate))
                    .FirstOrDefault();

            Console.WriteLine(customer.Name + " " + customer.CustomerID + "\n\r");
            foreach (var invoice in customer.Invoices.ToList())
            {
                Console.WriteLine(invoice.InvoiceID + " " + invoice.Customer.Name + " " + invoice.Date + "\r\n");
            }
        }
    }
}