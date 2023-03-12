using Domain.Interfaces.Services;
using Domain.Models.Clients;
using Domain.Models.Clients.Advice;

namespace Domain.Interfaces.Clients
{
    public interface IAdviceClient: IClientFactory<AdviceModel, ClientResponseModel>
    {
    }
}
