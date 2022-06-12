using System.Reflection;
using HospitalWebApi.Entity.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebApi.Entity
{
    public class HospitalContext : DbContext
    {
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }

        public HospitalContext()
        {
        }
        
        public HospitalContext(DbContextOptions<HospitalContext> options)
             : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(MedicamentEfConfiguration).GetTypeInfo().Assembly
            );
        }
    }
}