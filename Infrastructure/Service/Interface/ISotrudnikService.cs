using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface ISotrudnikService
    {
        Task AddSotrudnik(Sotrudnik sotrudnik);
        Task UpdateSotrudnik(Sotrudnik sotrudnik);
        Task DeleteSotrudnik(int id);
        Task<IEnumerable<Sotrudnik>> GetSotrudniksByMaritalStatus(string maritalStatus);
        Task<IEnumerable<Sotrudnik>> GetSotrudniksByEnglishKnowledge(string englishLevel);
        Task<Sotrudnik> GetSotrudnikById(int id);
    }
}
