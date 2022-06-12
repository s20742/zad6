using System.Linq;
using System.Threading.Tasks;
using HospitalWebApi.DTO;

namespace HospitalWebApi.Services.Interfaces
{
    public interface IPrescriptionDbService
    {
        Task<PrescriptionDTO> GetDataPrescriptionAsync(int idPrescription);
    }
}