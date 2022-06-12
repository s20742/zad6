using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalWebApi.Entity.Configuration
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient).HasName("Patient_pk");
            builder.Property(e => e.IdPatient).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Birthdate).IsRequired();

            builder.HasData(new Patient
            {
                IdPatient = 1,
                Birthdate = DateTime.Parse("1995-05-19"),
                FirstName = "Anna",
                LastName = "Szczęch"
            });
            
            builder.HasData(new Patient
            {
                IdPatient = 2,
                Birthdate = DateTime.Parse("1985-05-20"),
                FirstName = "Grzegorz",
                LastName = "Szczęch"
            });
            
            builder.ToTable("Patient");
        }
    }
}