using Domain.Models.Clients.Advice;

namespace Domain.Interfaces.Services
{
    public interface IAdviceService
    {
        Task<AdviceModel> Get();
    }
}
