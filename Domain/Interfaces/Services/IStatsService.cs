using Domain.DTO.StatsDTO;

namespace Domain.Interfaces.Services
{
    public interface IStatsService
    {
        public Task<StatsResponseDTO> GetStatsAsync();
    }
}
