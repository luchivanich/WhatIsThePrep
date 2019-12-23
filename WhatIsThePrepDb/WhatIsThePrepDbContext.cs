using Microsoft.EntityFrameworkCore;

namespace WhatIsThePrepDb
{
    public class WhatIsThePrepDbContext : DbContext
    {
        private string connString = "Data Source=witp.db";

        public DbSet<ExampleModel> Examples { get; set; }

        //public WhatIsThePrepDbContext()
        //{
        //    Database.EnsureCreated()
        //    Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connString);
        }
    }
}
