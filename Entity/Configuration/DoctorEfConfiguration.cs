using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalWebApi.Entity.Configuration
{
    public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor).HasName("Doctor_pk");
            builder.Property(e => e.IdDoctor).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);

            builder.HasData(new Doctor
            {
                IdDoctor = 1,
                Email = "asdfgh@gmail.com",
                FirstName = "Michał",
                LastName = "Bielecki"
            });
            builder.HasData(new Doctor
            {
                IdDoctor = 2,
                Email = "dasyudgiasdoas@gmail.com",
                FirstName = "Kamil",
                LastName = "Bielecki"
            });
            
            builder.ToTable("Doctor");
        }
    }
}