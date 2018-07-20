using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CBA.Store.Domain;

namespace CBA.Store.Data.Context
{
    /// <summary>
    /// EF code first database context
    /// </summary>
    public class EntityContext : DbContext
    {
        public EntityContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Product> Products { get; set; }
    }
}
