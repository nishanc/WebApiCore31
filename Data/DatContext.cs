using Microsoft.EntityFrameworkCore;
using WebApiCore31.Models;

namespace WebApiCore31.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}