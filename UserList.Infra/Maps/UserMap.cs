using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserList.Domain.Models;

namespace UserList.Infra.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60).HasColumnName("FirstName").HasColumnType("varchar(60)");
            builder.Property(x => x.Name.LastName).IsRequired().HasMaxLength(60).HasColumnName("LastName").HasColumnType("varchar(60)");
        }
    }
}