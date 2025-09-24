using Talabat.Domain.Entities.Identity;

namespace Talabat.Infrastructure.Persistence._Identity.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
           
            builder.Property(u=>u.DisplayName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(100);


            builder.HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
