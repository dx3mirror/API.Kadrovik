using API.ProjectKadrovik.ClaimRule.Interface;
using Application.DTOs.Inpuct;
using Domain.Entity;
using Infrastructure.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ProjectKadrovik.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IAuthService _authService;
        private readonly ISignInDefault _signInDefault;

        public LoginController(ILogger<LoginController> logger, IAuthService authService,ISignInDefault signInDefault)
        {
            _logger = logger;
            _authService = authService;
            _signInDefault = signInDefault;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost("/api/OnLogginAsync")]
        public async Task<IActionResult> OnLogginAsync(Users users)
        {
            _logger.LogInformation($"User {users.username} attempted login.");

            UserAutorization? user = await _authService.LoginAsync(users.username, users.password);

            if (user != null)
            {
                _logger.LogInformation($"Login successful for user {users.username}.");
                await _signInDefault.SignInAsync(HttpContext, users.username);
                return RedirectToRoute("default", new { controller = "Main", action = "Index" });
            }
            else
            {
                _logger.LogInformation($"Login failed for user {users.username}.");
                return Json(new { success = false, errorMessage = "Incorrect username or password" });
            }
        }
    }
}
