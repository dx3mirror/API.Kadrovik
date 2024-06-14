using Infrastructure.Entity;
using Infrastructure.Service.Interface;
namespace UseCases.SotrudnikCRUD.Sotrudniks
{
    public class AppService
    {
        private readonly ISotrudnikService _sotrudnikService;

        public AppService(ISotrudnikService sotrudnikService)
        {
            _sotrudnikService = sotrudnikService;
        }

        public async Task AddSotrudnik(Sotrudnik sotrudnik)
        {
            await _sotrudnikService.AddSotrudnik(sotrudnik);
        }

        public async Task UpdateSotrudnik(Sotrudnik sotrudnik)
        {
            await _sotrudnikService.UpdateSotrudnik(sotrudnik);
        }

        public async Task DeleteSotrudnik(int id)
        {
            await _sotrudnikService.DeleteSotrudnik(id);
        }

        public async Task<IEnumerable<Sotrudnik>> GetSotrudniksByMaritalStatus(string maritalStatus)
        {
            return await _sotrudnikService.GetSotrudniksByMaritalStatus(maritalStatus);
        }

        public async Task<IEnumerable<Sotrudnik>> GetSotrudniksByEnglishKnowledge(string englishLevel)
        {
            return await _sotrudnikService.GetSotrudniksByEnglishKnowledge(englishLevel);
        }

        public async Task<Sotrudnik> GetSotrudnikById(int id)
        {
            return await _sotrudnikService.GetSotrudnikById(id);
        }
    }
}
