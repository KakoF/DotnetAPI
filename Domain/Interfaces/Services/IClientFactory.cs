
namespace Domain.Interfaces.Services
{
    public interface IClientFactory<T, O>
    {
        Task<O> Get(string path);
        Task<O> Post(string path, T data);
    }
}
