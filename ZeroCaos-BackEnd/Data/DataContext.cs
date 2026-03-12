using Microsoft.EntityFrameworkCore;
using ZeroCaos_BackEnd.Models;

namespace ZeroCaos_BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
