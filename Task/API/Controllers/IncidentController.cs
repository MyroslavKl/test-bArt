using Application.Services;
using Domain.Exceptions;
using Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        
        [HttpPost("create-incident")]
        public async Task<IActionResult> CreateIncident([FromBody] IncidentRequest incidentRequest)
        {
            try
            {
                await _incidentService.CreateIncidentAsync(incidentRequest);
                
                return Ok("Incident created successfully.");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
    
}
