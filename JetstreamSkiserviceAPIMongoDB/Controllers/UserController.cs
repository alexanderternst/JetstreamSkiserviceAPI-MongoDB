using JetstreamSkiserviceAPIMongoDB.Models;
using JetstreamSkiserviceAPIMongoDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPIMongoDB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// User Controller Konstruktor mit instanziierung
        /// </summary>
        /// <param name="userService">Service Interface</param>
        /// <param name="logger">Logger</param>
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Post Methode welche Service aufruft und Authentifikation durchführt/JWT-Key ausgibt
        /// </summary>
        /// <param name="login">Login</param>
        /// <returns>ActionResult (JWT-Token)</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login(Authentification login)
        {
            try
            {
                List<User?> users = new List<User?>();
                users = _userService.Get();

                foreach (User? user in users)
                {
                    if (user.Username == login.Username && user.Password == login.Password && user.Counter < 3)
                    {
                        return new JsonResult(new { user_username = user.Username, token = _userService.CreateToken(user.Username) });
                    }
                    else if (user.Username == login.Username && user.Password != login.Password && user.Counter < 3)
                    {
                        user.Counter++;
                        _userService.Ban(user.Id);
                        return Unauthorized($"Invalid credentials. {3 - user.Counter} attempts left");
                    }
                    else if (user.Username == login.Username && user.Counter >= 3)
                    {
                        return BadRequest("This user has been banned. Please contact our support team.");
                    }
                    else
                    {
                        continue;
                    }
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Unban Methode welche Service aufruft und Benutzer entbannt
        /// </summary>
        /// <param name="id">user-id</param>
        /// <returns>ActionResult</returns>
        [HttpPut("unban/{id}")]
        public ActionResult Unban(string id)
        {
            try
            {
                _userService.Unban(id);
                return Content($"User with id {id} unbanned.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Get Methode welche Service aufruft und Benutzer mit Passwort auf null (aus Sicherheitsgründen) gesetzt ausgibt
        /// </summary>
        /// <returns>Liste von Benutzern</returns>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            try
            {
                List<User> users = _userService.Get();
                foreach (User user in users)
                {
                    user.Password = null;
                }
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

    }
}
