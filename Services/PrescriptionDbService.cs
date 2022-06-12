using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApi.DTO;
using HospitalWebApi.Entity;
using HospitalWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebApi.Services
{
    public class PrescriptionDbService : IPrescriptionDbService
    {
        private readonly HospitalContext _context;

        public PrescriptionDbService(HospitalContext context)
        {
            _context = context;
        }
        public async Task<PrescriptionDTO> GetDataPrescriptionAsync(int idPrescription)
        {
            return _context
                .Prescriptions
                .Where(x => x.IdPrescription == idPrescription)
                .Include(x => x.IdDoctorNavigation)
                .Include(y => y.IdPatientNavigation)
                .Include(x => x.PrescriptionMedicaments)
                    .ThenInclude(x => x.IdMedicamentNavigation)
                .Select(z => new PrescriptionDTO
                {
                    DueDate = z.DueDate,
                    Date = z.Date,
                    Doctor = new DoctorDTO
                    {
                        Email = z.IdDoctorNavigation.Email,
                        FirstName = z.IdDoctorNavigation.FirstName,
                        LastName = z.IdDoctorNavigation.LastName
                    },
                    Patient = new PatientDTO
                    {
                        Birthdate = z.IdPatientNavigation.Birthdate,
                        FirstName = z.IdPatientNavigation.FirstName,
                        LastName = z.IdPatientNavigation.LastName
                    },
                    Medicaments = z.PrescriptionMedicaments.Select(x => new MedicamentDTO
                    {
                        Description = x.IdMedicamentNavigation.Description,
                        Name = x.IdMedicamentNavigation.Name,
                        Type = x.IdMedicamentNavigation.Type,
                        Dose = x.Dose,
                        Details = x.Details
                        
                    }).ToList()
                    
                })
                .First();
        }
    }
}