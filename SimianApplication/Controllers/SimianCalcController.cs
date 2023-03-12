using Domain.DTO.SimianCalcDTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimianCalcController : ControllerBase
    {
        private readonly ISimianCalcService _service;

        public SimianCalcController(ISimianCalcService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<SimianCalcResponseDTO>> Get()
        {
            return await _service.GetAsync();
        }
    }
}