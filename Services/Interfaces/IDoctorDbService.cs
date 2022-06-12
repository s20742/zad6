using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalWebApi.DTO;
using HospitalWebApi.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApi.Services.Interfaces
{
    public interface IDoctorDbService
    {
        Task<List<DoctorDTO>> GetDoctorListAsync();
        Task<int> AddDoctorAsync(DoctorDTO doctor);
        Task<int> UpdateDoctorAsync(DoctorUpdateDTO doctor);
        Task<int> DeleteDoctorAsync(int idClient);
    }
}