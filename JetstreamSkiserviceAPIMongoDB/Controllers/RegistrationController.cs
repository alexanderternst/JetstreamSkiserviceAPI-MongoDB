using JetstreamSkiserviceAPIMongoDB.Models;
using JetstreamSkiserviceAPIMongoDB.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService _registrationService;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(IRegistrationService registrationService, ILogger<RegistrationController> logger)
        {
            _registrationService = registrationService;
            _logger = logger;
        }

        [HttpGet]
        public List<Registration> Get() => _registrationService.Get();

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
                // BadRequest
            }
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Registration updatedRegistration)
        {
            try
            {
                var registration = _registrationService.Get(id);
                if (registration == null)
                {
                    return NotFound();
                }
                updatedRegistration.Id = registration.Id;

                _registrationService.Update(id, updatedRegistration);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

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
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(Registration newRegistration)
        {
            try
            { 
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
