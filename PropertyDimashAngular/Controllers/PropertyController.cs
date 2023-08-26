using Microsoft.AspNetCore.Mvc;
using PropertyDimashAngular.Models;
using PropertyDimashAngular.Services;

namespace PropertyDimashAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return _propertyService.GetPropertyList();
        }

        [HttpGet("{id}")]
        public ActionResult<Property> Get(string id)
        {
            var property = _propertyService.GetPropertyById(id);

            if(property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        [HttpPost]
        [Route("Flat")]
        public ActionResult<Flat> PostFlat(Flat property)
        {
            _propertyService.CreatePropertyFlat(property);
            return CreatedAtAction("Post", new { id = property.Id }, property);
        }

        [HttpPost]
        [Route("House")]
        public ActionResult<House> PostHouse(House property)
        {
            _propertyService.CreatePropertyHouse(property);
            return CreatedAtAction("Post", new { id = property.Id }, property);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return BadRequest("Not a valid player id");
            }

            var property = _propertyService.GetPropertyById(id);

            if(property == null)
            {
                return NotFound();
            }

            _propertyService.DeleteProperty(property);
            return NoContent();
        }
    }
}
