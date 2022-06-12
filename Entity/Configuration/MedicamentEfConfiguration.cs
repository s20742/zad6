using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalWebApi.Entity.Configuration
{
    public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament).HasName("Medicament_pk");
            builder.Property(e => e.IdMedicament).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Type).IsRequired().HasMaxLength(100);

            builder.HasData(new Medicament
            {
                IdMedicament = 1,
                Name = "Lek 1",
                Description = "Desc 1",
                Type = "20"
            });
            
            builder.HasData(new Medicament
            {
                IdMedicament = 2,
                Name = "Lek 2",
                Description = "Desc 2",
                Type = "30"
            });
            
            builder.ToTable("Medicament");
        }
    }
} 