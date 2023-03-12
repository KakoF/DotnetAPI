using Domain.Interfaces.Services;
using Domain.Models.Clients;
using Domain.Models.Clients.ChuckNorris;

namespace Domain.Interfaces.Clients
{
    public interface IChuckNorrisClient : IClientFactory<ChuckNorrisModel, ClientResponseModel>
    {
    }
}
