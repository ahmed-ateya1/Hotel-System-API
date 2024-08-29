using AutoMapper;
using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.DTO;
using Hotel_System.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Hotel_System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly IVillaServices _villaService;
        private readonly IMapper _mapper;

        public VillaController(ILogger<VillaController> logger, IMapper mapper, IVillaServices villaService)
        {
            _logger = logger;
            _villaService = villaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            var response = new APIResponse();
            try
            {
                _logger.LogInformation("Getting all villas.");
                var listVilla = await _villaService.GetAllAysnc(); // Corrected with await
                response.StatusCode = HttpStatusCode.OK;
                response.Result = listVilla;
                response.IsSuccess = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpGet("{id:Guid}", Name = "GetVilla")]
        public async Task<ActionResult<APIResponse>> GetVilla(Guid id)
        {
            var response = new APIResponse();
            try
            {
                var villa = await _villaService.GetByAsync(x => x.VillaID == id); // Ensure await usage

                if (villa == null)
                {
                    _logger.LogInformation("Villa not found with ID: {Id}", id);
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    return NotFound(response);
                }

                _logger.LogInformation("Retrieved villa with ID: {Id}", id);
                response.Result = villa;
                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPost("createVilla")]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaAddRequest villaAddRequest)
        {
            var response = new APIResponse();
            try
            {
                if (villaAddRequest == null)
                {
                    _logger.LogWarning("CreateVilla request received with null villaAddRequest object.");
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    return BadRequest(response);
                }

                var villaResponse = await _villaService.CreateVillaAsync(villaAddRequest);
                response.Result = villaResponse;
                response.StatusCode = HttpStatusCode.Created;
                response.IsSuccess = true;
                _logger.LogInformation("Created new villa with ID: {VillaID}", villaResponse.VillaID);
                return CreatedAtRoute("GetVilla", new { id = villaResponse.VillaID }, response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<APIResponse>> UpdateVilla(Guid id, [FromBody] VillaUpdateRequest villaUpdate)
        {
            var response = new APIResponse();
            try
            {
                if (villaUpdate == null || id != villaUpdate.VillaID)
                {
                    _logger.LogWarning("UpdateVilla request received with invalid data.");
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    return BadRequest(response);
                }

                var villaResponse = await _villaService.UpdateVillaAsync(villaUpdate);
                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
                _logger.LogInformation("Updated villa with ID: {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<APIResponse>> DeleteVilla(Guid id)
        {
            var response = new APIResponse();
            try
            {
                var villa = await _villaService.GetByAsync(x => x.VillaID == id); // Ensure await usage

                if (villa == null)
                {
                    _logger.LogInformation("Villa not found for deletion with ID: {Id}", id);
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    return NotFound(response);
                }

                await _villaService.DeleteVillaAsync(id); // Add await here for delete async
                _logger.LogInformation("Deleted villa with ID: {Id}", id);
                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
                return NoContent();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
