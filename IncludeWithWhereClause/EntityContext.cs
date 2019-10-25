using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncludeWithWhereClause
{
   public class EntityContext: DbContext
    {
        public EntityContext() : base("name=EntityContext")
        { 
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
