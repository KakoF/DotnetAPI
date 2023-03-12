
namespace Infra.Interfaces
{
    public interface IStorageCache
    {
        Task<T> GetAsync<T>(string key);
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> function);
        void Set<T>(string key, T data);
        void Remove(string key);


    }
}
