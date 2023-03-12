using Domain.DTO.IsSimianDTO;
using Domain.DTO.SimianDTO;

namespace Domain.Interfaces.Services
{
    public interface ISimianService
    {
        Task<IsSimianResponseDTO> VerifyDnaAsync(IsSimianRequestDTO data);
        Task<SimianResponseDTO> Get(int id);
    }
}
