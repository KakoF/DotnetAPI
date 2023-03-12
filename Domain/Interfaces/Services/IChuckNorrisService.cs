using Domain.Models.Clients.ChuckNorris;

namespace Domain.Interfaces.Services
{
    public interface IChuckNorrisService
    {
        Task<ChuckNorrisModel> Get();
    }
}
