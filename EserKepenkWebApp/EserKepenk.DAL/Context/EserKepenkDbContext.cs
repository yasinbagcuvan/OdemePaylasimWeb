using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Context
{
    public class EserKepenkDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public EserKepenkDbContext(DbContextOptions<EserKepenkDbContext> options) : base(options)
        {
            
        }
    }
}
