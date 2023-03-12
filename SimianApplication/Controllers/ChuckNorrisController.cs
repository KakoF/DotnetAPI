using Domain.DTO.IsSimianDTO;
using Domain.DTO.StatsDTO;
using Domain.Interfaces.Services;
using Domain.Models.Clients.Advice;
using Domain.Models.Clients.ChuckNorris;
using Microsoft.AspNetCore.Mvc;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChuckNorrisController : ControllerBase
    {
        private readonly IChuckNorrisService _service;

        public ChuckNorrisController(IChuckNorrisService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ChuckNorrisModel> Get()
        {
            return await _service.Get();
        }
    }
}