using JetstreamSkiserviceAPIMongoDB.Models;
using JetstreamSkiserviceAPIMongoDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPIMongoDB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService _registrationService;
        private readonly ILogger<RegistrationController> _logger;
        
        /// <summary>
        /// Registration Controller Konstruktor mit instanziierung
        /// </summary>
        /// <param name="registrationService">Service Interface</param>
        /// <param name="logger">Logger</param>
        public RegistrationController(IRegistrationService registrationService, ILogger<RegistrationController> logger)
        {
            _registrationService = registrationService;
            _logger = logger;
        }

        /// <summary>
        /// Get Methode welche Service aufruft und Registrationen abruft
        /// </summary>
        /// <returns>Liste von Registrationen</returns>
        [AllowAnonymous]
        [HttpGet]
        public List<Registration> Get() => _registrationService.Get();

        /// <summary>
        /// GetById Methode welche Service aufruft und Registration nach id aufruft
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Registration</returns>
        [HttpGet("{id:length(24)}")]
        public ActionResult<Registration> Get(string id)
        {
            try
            {
                var registration = _registrationService.Get(id);
                if (registration == null)
                {
                    return NotFound();
                }
                return registration;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Update Methode welche Service aufruft und Registration modifiziert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="updatedRegistration">Geänderte Daten</param>
        /// <returns>ActionResult</returns>
        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Registration updatedRegistration)
        {
            try
            {
                updatedRegistration.Id = null;
                var registration = _registrationService.Get(id);
                if (registration == null)
                {
                    return NotFound();
                }
                updatedRegistration.Id = registration.Id;

                _registrationService.Update(id, updatedRegistration);
                return CreatedAtAction(nameof(Get), new { id = updatedRegistration.Id }, updatedRegistration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Delete Methode welche Service aufruft und Registration löscht
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>ActionResult</returns>
        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var registration = _registrationService.Get(id);
                if (registration == null)
                {
                    return NotFound();
                }
                _registrationService.Delete(id);
                return Content($"Registration with id {id} deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Post Methode welche Service aufruft und Registration erstellt
        /// </summary>
        /// <param name="newRegistration">Neue Daten</param>
        /// <returns>ActionResult</returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Post(Registration newRegistration)
        {
            try
            {
                // TO-DO: JSONIgnore for Id
                newRegistration.Id = null;

                _registrationService.Create(newRegistration);
                return CreatedAtAction(nameof(Get), new { id = newRegistration.Id }, newRegistration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}
