using AutoMapper;
using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.DTO;
using Hotel_System.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotel_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly IVillaNumberServices _villaNumberServices;
        private readonly ILogger<VillaNumberController> _logger;
        private readonly IMapper _mapper;

        public VillaNumberController(IVillaNumberServices villaNumberServices,
            ILogger<VillaNumberController> logger,
            IMapper mapper)
        {
            _villaNumberServices = villaNumberServices;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillasNumber()
        {
            var response = new APIResponse();
            try
            {
                _logger.LogInformation("Getting all villas number.");
                var villaList = await _villaNumberServices.GetAllAsync();

                response.StatusCode = HttpStatusCode.OK;
                response.Result = villaList;
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
        [HttpGet("{id:int}" , Name = "GetVillaNumber")]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            var response = new APIResponse();
            try
            {
                var villaNumber = await _villaNumberServices.GetByAsync(x=>x.VillaNum == id);
                if(villaNumber == null)
                {
                    _logger.LogInformation("Villa Number not found with ID: {Id}", id);
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess=false;
                    return NotFound(response);
                }
                _logger.LogInformation("Retrieved villa number with ID: {Id}", id);
                response.IsSuccess = true;
                response.StatusCode=HttpStatusCode.OK;
                response.Result = villaNumber;
                return Ok(response);
                    
            }
            catch(Exception ex) 
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIResponse>> PostCreate([FromBody] VillaNumberAddRequest villaNumberAdd)
        {
            var response = new APIResponse();

            try
            {
                if (villaNumberAdd == null)
                {
                    _logger.LogWarning("Create Villa Number request received with null villaNumberAdd object.");
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    return BadRequest(response);
                }
                if (await _villaNumberServices.GetByAsync(x => x.VillaNum == villaNumberAdd.VillaNum , isTracked: false) != null)
                {
                    ModelState.AddModelError(String.Empty, "Villa Number Already Exists!");
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(response);
                }

                var createdVilla = await _villaNumberServices.CreateAsync(villaNumberAdd);
                response.StatusCode = HttpStatusCode.Created;
                response.IsSuccess = true;
                response.Result = createdVilla; 
                _logger.LogInformation("Created new villa number with ID: {VillaNum}", createdVilla.VillaNum);
                return CreatedAtRoute("GetVillaNumber", new { id = createdVilla.VillaNum }, response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<APIResponse>> PutUpdate(int id , [FromBody] VillaNumberUpdateRequest villaNumberUpdate)
        {
            var response = new APIResponse();
            try
            {
                if (villaNumberUpdate == null || id != villaNumberUpdate.VillaNum)
                {
                    _logger.LogWarning("Update Villa request received with null villaNumberUpdate object.");
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    return BadRequest(response);
                }
               
                var villaNumberResponse = await _villaNumberServices.UpdateAsync(villaNumberUpdate);
                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
                _logger.LogInformation("Updated villa number with ID: {Id}", id);
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
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int? id)
        {
            var response = new APIResponse();
            try
            {
                if(id == null)
                {
                    response.IsSuccess =false;
                    response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(response);
                }
                var villaNumberResponse = await _villaNumberServices.GetByAsync(x => x.VillaNum == id);
                if(villaNumberResponse == null)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                await _villaNumberServices.DeleteAsync(id);
                _logger.LogInformation("Deleted villa number with ID: {Id}", id);
                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
                return NoContent();
            }
            catch(Exception ex) 
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
