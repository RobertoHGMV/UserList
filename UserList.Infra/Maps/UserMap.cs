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
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
        }
    }
}