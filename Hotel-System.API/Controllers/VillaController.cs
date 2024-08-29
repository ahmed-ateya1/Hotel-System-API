using AutoMapper;
using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.DTO;
using Hotel_System.Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public VillaController(ILogger<VillaController> logger, IMapper mapper, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaResponse>> GetVillas()
        {
            _logger.LogInformation("Getting all villas.");
            var listVilla = _db.Villas.ToList();    
            return Ok(_mapper.Map<List<VillaResponse>>(listVilla));
        }

        [HttpGet("{id:Guid}", Name = "GetVilla")]
        public ActionResult<VillaResponse> GetVilla(Guid? id)
        {
            if (!id.HasValue)
            {
                _logger.LogWarning("Invalid ID provided for GetVilla: {Id}", id);
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(x => x.VillaID == id);
            if (villa == null)
            {
                _logger.LogInformation("Villa not found with ID: {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Retrieved villaAddRequest with ID: {Id}", id);
            return Ok(_mapper.Map<VillaResponse>(villa));
        }

        [HttpPost("createVilla")]
        public IActionResult CreateVilla(VillaAddRequest villaAddRequest)
        {
            if (villaAddRequest == null)
            {
                _logger.LogWarning("CreateVilla request received with null villaAddRequest object.");
                return BadRequest();
            }
            var villaReponse = _mapper.Map<VillaResponse>(villaAddRequest);

            villaReponse.VillaID = Guid.NewGuid();
            var villa = _mapper.Map<Villa>(villaReponse);
            _db.Villas.Add(villa);
            _db.SaveChanges();

            _logger.LogInformation("Created new villaAddRequest with ID: {VillaID}", villa.VillaID);
            return CreatedAtRoute("GetVilla", new { id = villa.VillaID }, villaAddRequest);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult UpdateVilla(Guid? id, [FromBody] Villa villa)
        {
            if (villa == null || !id.HasValue)
            {
                _logger.LogWarning("UpdateVilla request received with null villaAddRequest object or missing ID.");
                return BadRequest();
            }

            var oldVilla = _db.Villas.FirstOrDefault(x => x.VillaID == id);
            if (oldVilla == null)
            {
                _logger.LogInformation("Villa not found for update with ID: {Id}", id);
                return NotFound();
            }

            oldVilla.VillaName = villa.VillaName;
            oldVilla.Occupancy = villa.Occupancy;
            oldVilla.Sqft = villa.Sqft;
            oldVilla.Rate = villa.Rate;
            oldVilla.UpdatedDate = villa.UpdatedDate;
            oldVilla.VillaDescription = villa.VillaDescription;
            oldVilla.Amenity = villa.Amenity;

            _db.Update(oldVilla);
            _db.SaveChanges();  

            _logger.LogInformation("Updated villaAddRequest with ID: {Id}", id);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteVilla(Guid? id)
        {
            if (!id.HasValue)
            {
                _logger.LogWarning("DeleteVilla request received with missing ID.");
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(x => x.VillaID == id);
            if (villa == null)
            {
                _logger.LogInformation("Villa not found for deletion with ID: {Id}", id);
                return NotFound();
            }

            _db.Villas.Remove(villa);
            _db.SaveChanges();
            _logger.LogInformation("Deleted villaAddRequest with ID: {Id}", id);
            return NoContent();
        }

        [HttpPatch("{id:Guid}")]
        public IActionResult UpdatePartialVilla(Guid? id, JsonPatchDocument<Villa> patch)
        {
            if (!id.HasValue || patch == null)
            {
                _logger.LogWarning("UpdatePartialVilla request received with invalid ID or patch document.");
                return BadRequest("Invalid ID or patch document.");
            }

            var villa = _db.Villas.FirstOrDefault(x => x.VillaID == id);
            if (villa == null)
            {
                _logger.LogInformation("Villa not found for partial update with ID: {Id}", id);
                return NotFound("Villa not found.");
            }

            patch.ApplyTo(villa, ModelState);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid ModelState after applying patch to villaAddRequest with ID: {Id}", id);
                return BadRequest(ModelState);
            }

            _db.Update(villa);
            _db.SaveChanges();

            _logger.LogInformation("Partially updated villaAddRequest with ID: {Id}", id);
            return NoContent();
        }

    }
}
