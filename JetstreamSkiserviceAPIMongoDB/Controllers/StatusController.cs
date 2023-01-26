using JetstreamSkiserviceAPIMongoDB.Models;
using JetstreamSkiserviceAPIMongoDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPIMongoDB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusService _statusService;
        private readonly ILogger<StatusController> _logger;

        public StatusController(IStatusService statusService, ILogger<StatusController> logger)
        {
            _statusService = statusService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Registration>> Get()
        {
            try
            {
                return _statusService.Get();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet("{status}")]
        public ActionResult<List<Registration>> Get(string status)
        {
            try
            {
                var registration = _statusService.Get(status);
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
    }
}
