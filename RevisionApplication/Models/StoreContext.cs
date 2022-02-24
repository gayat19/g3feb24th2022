using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevisionApplication.Models
{
    public class StoreContext :DbContext
    {
        public StoreContext()
        {

        }
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Username="abc",Password="123",Role="Admin"}
                );
        }
    }
}
