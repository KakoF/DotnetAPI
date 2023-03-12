using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.DTO.StatsDTO;
using Domain.Interfaces.Cache;
using Domain.DTO.SimianCalcDTO;

namespace Service.Services
{
    public class SimanCalcService : ISimianCalcService
    {
        private readonly ISimianCalcRepository _repository;
        private readonly ICacheMethods _cahceMetods;

        public SimanCalcService(ISimianCalcRepository repository, ICacheMethods cacheMethods)
        {
            _repository = repository;
            _cahceMetods = cacheMethods;
        }

        public async Task<IEnumerable<SimianCalcResponseDTO>> GetAsync()
        {
            var data = (await _cahceMetods.GetOrCreateAsync("List_SimianCalcEntity", async () => await _repository.GetAllAsync())).ListDTO();
            return data;
            
        }

    }
}
