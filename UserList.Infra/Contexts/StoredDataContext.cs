using Microsoft.EntityFrameworkCore;
using UserList.Domain.Models;
using UserList.Infra.Maps;
using UserList.Shared;

namespace UserList.Infra.Contexts
{
    public class StoredDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(Runtime.ConnectionStringMysql);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}