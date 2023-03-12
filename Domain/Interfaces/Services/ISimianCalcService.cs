using Domain.DTO.SimianCalcDTO;

namespace Domain.Interfaces.Services
{
    public interface ISimianCalcService
    {
        public Task<IEnumerable<SimianCalcResponseDTO>> GetAsync();
    }
}
