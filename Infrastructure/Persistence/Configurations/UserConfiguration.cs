using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoon.Domain.UserManagement;

namespace MyMoon.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength200().IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength200().IsRequired(true);
            builder.OwnsOne(x => x.ProfilePicture, x =>
            {
                x.Property(x => x.FileName).HasMaxLength200().HasColumnName("ProfilePictureFileName");
                x.Property(x => x.Extension).HasMaxLength(10).HasColumnName("ProfilePictureExtension");
            });
            builder.Property(x => x.About).HasMaxLength800();

            builder.ToTable("Users");
        }
    }
}
