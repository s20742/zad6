using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalWebApi.Entity.Configuration
{
    public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(e => new {e.IdMedicament, e.IdPrescription}).HasName("PrescriptionMedicament_pk");

            builder.Property(e => e.Dose).IsRequired();
            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);


            builder.HasOne(e => e.IdMedicamentNavigation)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .HasConstraintName("PrescriptionMedicament_Medicament")
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            builder.HasOne(e => e.IdPrescriptionNavigation)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription)
                .HasConstraintName("PrescriptionMedicament_Prescription")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasData(new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 15,
                Details = "test 1"
            });
            
            builder.HasData(new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 1,
                Dose = 30,
                Details = "test 2"
            });
            
            builder.HasData(new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 45,
                Details = "test 3"
            });
            
            builder.ToTable("PrescriptionMedicament");
        }
    }
}