using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User {
                    Id = 1,
                    Name = "Rajin",
                    Email = "rajin@gmail.com",
                    Password = "R@r12345" ,
                    PhoneNumber = "9823412254",
                    Address ="Kathmandu"
                },
                new User {
                    Id = 2,
                    Name = "Milan",
                    Email = "milan@gmail.com",
                    Password = "M@m12345" ,
                    PhoneNumber = "9845412354",
                    Address ="Bhaktapur"
                },
                new User {
                    Id = 3,
                    Name = "Gagan",
                    Email = "gagan@gmail.com",
                    Password = "G@g12345" ,
                    PhoneNumber = "9845214563",
                    Address ="Lalitpur"
                },

            });
        }
    }
}
