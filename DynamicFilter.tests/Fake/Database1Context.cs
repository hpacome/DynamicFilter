using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFilter.tests.Fake
{
    public class Database1Context : DbContext
    {
        public Database1Context(DbContextOptions<Database1Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public DbSet<ExempleStringEntity> ExempleStringEntities { get; set; }
        public DbSet<ExempleInt32Entity> ExempleInt32Entities { get; set; }
        public DbSet<ExempleNullableInt32Entity> ExempleNullableInt32Entities { get; set; }
    }
}
