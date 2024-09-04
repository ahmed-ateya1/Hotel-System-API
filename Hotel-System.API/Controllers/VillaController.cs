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
    /// <summary>
    /// API Controller for managing villa-related operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly IVillaServices _villaService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="VillaController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="villaService">The villa service instance for handling business logic.</param>
        public VillaController(ILogger<VillaController> logger, IMapper mapper, IVillaServices villaService)
        {
            _logger = logger;
            _villaService = villaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all villas.
        /// </summary>
        /// <returns>A list of villas wrapped in an <see cref="APIResponse"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            var response = new APIResponse();
            try
            {
                _logger.LogInformation("Getting all villas.");
                var listVilla = await _villaService.GetAllAysnc();
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

        /// <summary>
        /// Retrieves a specific villa by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the villa.</param>
        /// <returns>The villa details wrapped in an <see cref="APIResponse"/>.</returns>
        [HttpGet("{id:Guid}", Name = "GetVilla")]
        public async Task<ActionResult<APIResponse>> GetVilla(Guid id)
        {
            var response = new APIResponse();
            try
            {
                var villa = await _villaService.GetByAsync(x => x.VillaID == id);

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

        /// <summary>
        /// Creates a new villa.
        /// </summary>
        /// <param name="villaAddRequest">The request object containing villa details.</param>
        /// <returns>The created villa details wrapped in an <see cref="APIResponse"/>.</returns>
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

        /// <summary>
        /// Updates an existing villa.
        /// </summary>
        /// <param name="id">The unique identifier of the villa to be updated.</param>
        /// <param name="villaUpdate">The request object containing updated villa details.</param>
        /// <returns>An <see cref="APIResponse"/> indicating the result of the update operation.</returns>
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

        /// <summary>
        /// Deletes a specific villa by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the villa to be deleted.</param>
        /// <returns>An <see cref="APIResponse"/> indicating the result of the delete operation.</returns>
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<APIResponse>> DeleteVilla(Guid id)
        {
            var response = new APIResponse();
            try
            {
                var villa = await _villaService.GetByAsync(x => x.VillaID == id);

                if (villa == null)
                {
                    _logger.LogInformation("Villa not found for deletion with ID: {Id}", id);
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    return NotFound(response);
                }

                await _villaService.DeleteVillaAsync(id);
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
