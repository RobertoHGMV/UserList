using Microsoft.EntityFrameworkCore;
using UserList.Commom;
using UserList.Domain.Models;
using UserList.Infra.Maps;

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