using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Domain.DTO.StatsDTO;

namespace Service.Services
{
    public class StatsService : IStatsService
    {
        private readonly ISimianCalcRepository _repository;

        public StatsService(ISimianCalcRepository repository)
        {
            _repository = repository;
        }

        public async Task<StatsResponseDTO> GetStatsAsync()
        {
            var simianCalc = await _repository.GetAsync();
            return new StatsResponseDTO(simianCalc.CountIsSimian, simianCalc.CountIsHuman, simianCalc.Ratio);
        }

    }
}
