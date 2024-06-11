using Infrastructure.Entity;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class SotrudnikRepository : ISotrudnikRepository
    {
        private readonly KadrovikFull1Context _context;

        public SotrudnikRepository(KadrovikFull1Context context)
        {
            _context = context;
        }

        public async Task AddAsync(Sotrudnik sotrudnik)
        {
            try
            {
                _context.Sotrudniks.Add(sotrudnik);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(Sotrudnik sotrudnik)
        {
            try
            {
                _context.Sotrudniks.Update(sotrudnik);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Обработка ошибки обновления
                Console.WriteLine($"Ошибка при обновлении: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var sotrudnik = await GetByIdAsync(id);
                if (sotrudnik != null)
                {
                    sotrudnik.Del = "Да"; // Помечаем для удаления
                    await UpdateAsync(sotrudnik);
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибки удаления
                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Sotrudnik>> GetByMaritalStatusAsync(string maritalStatus)
        {
            try
            {
                return await _context.Sotrudniks.Where(s => s.Brak == maritalStatus && s.Del != "Нет").ToListAsync();
            }
            catch (Exception ex)
            {
                // Обработка ошибки выборки
                Console.WriteLine($"Ошибка при выборке: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Sotrudnik>> GetByEnglishKnowledgeAsync(string englishLevel)
        {
            try
            {
                return await _context.Sotrudniks.Where(s => s.InYz == englishLevel && s.Del != "Нет").ToListAsync();
            }
            catch (Exception ex)
            {
                // Обработка ошибки выборки
                Console.WriteLine($"Ошибка при выборке: {ex.Message}");
                throw;
            }
        }

        public async Task<Sotrudnik> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Sotrudniks.FirstOrDefaultAsync(s => s.Id == id && s.Del != "Нет");
            }
            catch (Exception ex)
            {
                // Обработка ошибки выборки
                Console.WriteLine($"Ошибка при выборке: {ex.Message}");
                throw;
            }
        }
    }
}
