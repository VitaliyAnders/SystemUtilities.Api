using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Linq;
using SystemData.BL.Api;

namespace SystemData.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/SystemProcess")]
    [EnableCors("AllowSpecificOrigin")]
    public class SystemProcessController : Controller
    {
        private readonly ISystemProcessFacade _spFacade;
        private readonly ILogger<SystemProcessController> _logger;

        public SystemProcessController(
            ISystemProcessFacade systemProcessFacade,
            ILogger<SystemProcessController> logger)
        {
            _spFacade = systemProcessFacade;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var process = _spFacade.GetAllRunningProcessNames();
                return Ok(process.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError("SystemProcessController.GetAll throw", ex);
                return null;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult StopProcess(int id)
        {
            try
            {
                if (_spFacade.StopProcess(id))
                    return Ok();
                return NotFound();
            }
            catch(Exception ex)
            {
                if ( (ex is Win32Exception) && 
                    (ex.Message.Contains("Access is denied")))
                    return StatusCode(403);

                _logger.LogError("SystemProcessController.GetAll StopProcess", ex);
                return StatusCode(500);
            }
        }
    }
}