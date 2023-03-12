using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.DTO.IsSimianDTO;
using Domain.Interfaces.Notifications;
using Domain.Notifications;
using Domain.DTO.SimianDTO;
using System.Diagnostics.Metrics;
using Prometheus;

namespace Service.Services
{
    public class SimianService : ISimianService
    {
        private readonly ILogger<SimianService> _logger;
        private readonly ISimianPatternsExecute _patternsExecute;
        private readonly ISimianRepository _repository;
        private readonly INotificationHandler<Notification> _notification;
        private Counter counter = Metrics.CreateCounter("ResultVerifyDna", "SimianService", new CounterConfiguration
        {
            LabelNames = new[] { "isSimian"}
        });

        public SimianService(ILogger<SimianService> logger, ISimianPatternsExecute patternsExecute, ISimianRepository repository, INotificationHandler<Notification> notification)
        {
            _logger = logger;
            _patternsExecute = patternsExecute;
            _repository = repository;
            _notification = notification;
        }
        public async Task<IsSimianResponseDTO> VerifyDnaAsync(IsSimianRequestDTO data)
        {
            _logger.LogWarning("Inicio de analise do Dna: {0}", string.Join(",", data.Dna));
            var isSimian = ParseArray(_patternsExecute.Execute(data.Dna)).Where(x => x.Equals(true)).Count() >= 2;
            var simian = new SimianEntity(string.Join(",", data.Dna), isSimian);
            await _repository.CreateAsync(simian);
            counter.WithLabels(simian.IsSimian.ToString()).Inc();
            
            return new IsSimianResponseDTO(simian.IsSimian);
        }

        public async Task<SimianResponseDTO> Get(int id)
        {
            var response = await _repository.GetAsync(id);
            if (response == null)
            {
                _notification.AddNotification(404, "Simian não encontrado", $"Não foi possível encontrar simian referente ao id {id}");
                _notification.AddNotification(404, "Simian not found", $"Can't found simin at id {id}");
                return null;
            }
            return new SimianResponseDTO(response.Id, response.Dna, response.IsSimian);
        }

        private IEnumerable<bool> ParseArray(IEnumerable<bool[]> array)
        {
            List<bool> list = new List<bool>();
            foreach (var result in array)
            {
                list.AddRange(result);
            }
            return list;

        }

    }
}
