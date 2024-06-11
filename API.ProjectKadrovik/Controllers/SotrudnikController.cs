using Infrastructure.Entity;
using Infrastructure.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ProjectKadrovik.Controllers
{
    public class SotrudnikController : Controller
    {
        private readonly ISotrudnikService _sotrudnikService;
        private readonly ILogger<SotrudnikController> _logger;

        public SotrudnikController(ISotrudnikService sotrudnikService, ILogger<SotrudnikController> logger)
        {
            _sotrudnikService = sotrudnikService;
            _logger = logger;
        }

        [HttpGet("maritalstatus/{maritalStatus}")]
        public async Task<ActionResult<IEnumerable<Sotrudnik>>> GetSotrudniksByMaritalStatus(string maritalStatus)
        {
            try
            {
                var sotrudniks = await _sotrudnikService.GetSotrudniksByMaritalStatus(maritalStatus);
                return Ok(sotrudniks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting sotrudniks by marital status");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("englishknowledge/{englishLevel}")]
        public async Task<ActionResult<IEnumerable<Sotrudnik>>> GetSotrudniksByEnglishKnowledge(string englishLevel)
        {
            try
            {
                var sotrudniks = await _sotrudnikService.GetSotrudniksByEnglishKnowledge(englishLevel);
                return Ok(sotrudniks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting sotrudniks by English knowledge");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sotrudnik>> GetSotrudnikById(int id)
        {
            try
            {
                var sotrudnik = await _sotrudnikService.GetSotrudnikById(id);
                if (sotrudnik == null)
                {
                    return NotFound();
                }
                return Ok(sotrudnik);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting sotrudnik by id");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddSotrudnik(Sotrudnik sotrudnik)
        {
            try
            {
                await _sotrudnikService.AddSotrudnik(sotrudnik);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding sotrudnik");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSotrudnik(int id, Sotrudnik sotrudnik)
        {
            try
            {
                // Установка ID сотрудника
                sotrudnik.Id = id;
                await _sotrudnikService.UpdateSotrudnik(sotrudnik);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating sotrudnik");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSotrudnik(int id)
        {
            try
            {
                await _sotrudnikService.DeleteSotrudnik(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting sotrudnik");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
