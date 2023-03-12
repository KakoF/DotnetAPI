using Domain.DTO.StatsDTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _service;
        Counter counter = Metrics.CreateCounter("requisicao_endpoint_stats", "StatsController");
        /*Gauge gauge = Metrics.CreateGauge("teste_gauge", "StatsController");
        Histogram histogram = Metrics.CreateHistogram("teste_histogram", "StatsController");
        Summary summary = Metrics.CreateSummary("teste_summary", "StatsController");*/

        public StatsController(IStatsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<StatsResponseDTO> Get()
        {
            counter.Inc();
            //counter.IncToCurrentTimeUtc();
            return await _service.GetStatsAsync();
        }
    }
}