using Lemondo_Web_API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_API.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        public DbSet<Statement> Statements { get; set; }
        public DbSet<StatementDetail> StatementDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statement>().HasData(
                new Statement { Id = 1, Title = "Phil Murphy ", StatementDetailId = 1 },
                new Statement { Id = 2, Title = "Phil Murphy ", StatementDetailId = 2 },
                new Statement { Id = 3, Title = "Phil Murphy ", StatementDetailId = 3 },
                new Statement { Id = 4, Title = "Phil Murphy ", StatementDetailId = 4 },
                new Statement { Id = 5, Title = "Phil Murphy ", StatementDetailId = 5 }
            );
            modelBuilder.Entity<StatementDetail>().HasData(
                new StatementDetail { StatementDetailId = 1, Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", PhoneNumber = "+995 556 52 26 36" },
                new StatementDetail { StatementDetailId = 2, Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", PhoneNumber = "+995 556 52 26 36" },
                new StatementDetail { StatementDetailId = 3, Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", PhoneNumber = "+995 556 52 26 36" },
                new StatementDetail { StatementDetailId = 4, Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", PhoneNumber = "+995 556 52 26 36" },
                new StatementDetail { StatementDetailId = 5, Description = "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", PhoneNumber = "+995 556 52 26 36" }
            );

        }
    }
}
