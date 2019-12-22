using Microsoft.EntityFrameworkCore;

namespace WhatIsThePrepDb
{
    public class WhatIsThePrepDbContext : DbContext
    {
        public DbSet<Example> Examples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=witp.db");
        }
    }
}
