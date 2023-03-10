using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainData.Models;
using Microsoft.EntityFrameworkCore;


namespace Services.Repositories
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { }

        public DbSet<Merchandise> Merchandises { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
