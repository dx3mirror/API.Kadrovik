
using Infrastructure.Entity;

namespace Infrastructure.Repository.Interface
{
    public interface ISotrudnikRepository
    {
        Task AddAsync(Sotrudnik sotrudnik);
        Task UpdateAsync(Sotrudnik sotrudnik);
        Task DeleteAsync(int id);
        Task<IEnumerable<Sotrudnik>> GetByMaritalStatusAsync(string maritalStatus);
        Task<IEnumerable<Sotrudnik>> GetByEnglishKnowledgeAsync(string englishLevel);
        Task<Sotrudnik> GetByIdAsync(int id);
    }
}
