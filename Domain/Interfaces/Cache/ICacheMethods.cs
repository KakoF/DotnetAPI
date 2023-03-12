
namespace Domain.Interfaces.Cache
{
    public interface ICacheMethods
    {
        Task<T> GetAsync<T>(string key, Func<Task<T>> function);
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> function);
        void Set<T>(string key, T data);
        void Remove(string key);
    }
}
