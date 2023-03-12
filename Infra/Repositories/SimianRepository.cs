using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Interfaces;
using Dapper;

namespace Infra.Repositories
{
    public class SimianRepository : ISimianRepository
    {
        private readonly IDbConnector _connector;
        public SimianRepository(IDbConnector connector)
        {
            _connector = connector;
        }
        public async Task<SimianEntity> CreateAsync(SimianEntity data)
        {
            var entity = await _connector.dbConnection.QuerySingleAsync<SimianEntity>("INSERT INTO Simian(dna, is_simian) VALUES (@dna, @isSimian) RETURNING  id, dna, is_simian as IsSimian, created_at as CreatedAt, updated_at as UpdatedAt ;", new { dna = data.Dna, isSimian = data.IsSimian });
            return entity;
        }

        public async Task<IEnumerable<SimianEntity>> GetAsync()
        {
            return await _connector.dbConnection.QueryAsync<SimianEntity>("Select id, dna, is_simian as IsSimian, created_at as CreatedAt, updated_at as UpdatedAt from Simian");

        }

        public async Task<SimianEntity> GetAsync(int id)
        {
            return await _connector.dbConnection.QueryFirstOrDefaultAsync<SimianEntity>("Select id, dna, is_simian as IsSimian, created_at as CreatedAt, updated_at as UpdatedAt from Simian where id = @id", new { id });
        }

        public async Task<SimianEntity> GetAsync(string dna)
        {
            return await _connector.dbConnection.QueryFirstOrDefaultAsync<SimianEntity>("Select id, dna, is_simian as IsSimian, created_at as CreatedAt, updated_at as UpdatedAt from Simian where dna = @dna", new { dna });
        }
    }
}
