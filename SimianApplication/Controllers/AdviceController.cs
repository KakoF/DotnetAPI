using Domain.DTO.IsSimianDTO;
using Domain.DTO.StatsDTO;
using Domain.Interfaces.Services;
using Domain.Models.Clients.Advice;
using Microsoft.AspNetCore.Mvc;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdviceController : ControllerBase
    {
        private readonly IAdviceService _service;

        public AdviceController(IAdviceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<AdviceModel> Get()
        {
            return await _service.Get();
        }
    }
}