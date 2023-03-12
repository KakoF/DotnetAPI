using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ISimianRepository
    {
        Task<SimianEntity> CreateAsync(SimianEntity data);

        Task<IEnumerable<SimianEntity>> GetAsync();

        Task<SimianEntity> GetAsync(int id);

        Task<SimianEntity> GetAsync(string dna);

       
    }
}
