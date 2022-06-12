using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApi.DTO;
using HospitalWebApi.Entity;
using HospitalWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebApi.Services
{
    public class DoctorDbService : IDoctorDbService
    {
        private readonly HospitalContext _context;

        public DoctorDbService(HospitalContext context)
        {
            _context = context;
        }
        public Task<List<DoctorDTO>> GetDoctorListAsync()
        {
            return _context
                .Doctors
                .Select(x => new DoctorDTO
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToListAsync();
        }

        public Task<int> AddDoctorAsync(DoctorDTO doctor)
        {
            _context
                .Doctors
                .AddAsync(new Doctor
                {
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email
                });
            
            try
            {
                return _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Task.FromResult(0);
            }
        }

        public Task<int> UpdateDoctorAsync(DoctorUpdateDTO doctor)
        {
            bool doUpdate = false;
            
            var toUpdate = _context
                .Doctors
                .First(x => x.IdDoctor == doctor.IdDoctor);

            if (!String.IsNullOrEmpty(doctor.FirstName) && doctor.FirstName != "string")
            {
                toUpdate.FirstName = doctor.FirstName;
                doUpdate = true;
            }

            if (!String.IsNullOrEmpty(doctor.LastName) && doctor.LastName != "string")
            {
                toUpdate.LastName = doctor.LastName;
                doUpdate = true;
            }

            if (!String.IsNullOrEmpty(doctor.Email) && doctor.Email != "string")
            {
                toUpdate.Email = doctor.Email;
                doUpdate = true;
            }

            try
            {
                if (doUpdate)
                    return _context.SaveChangesAsync();
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                return Task.FromResult(0);
            }
        }

        public Task<int> DeleteDoctorAsync(int idDoctor)
        {
            var toDelete = _context
                .Doctors
                .First(x => x.IdDoctor == idDoctor);

            _context.Remove(toDelete);
            try
            {
                return _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Task.FromResult(0);
            }
        }
    }
}