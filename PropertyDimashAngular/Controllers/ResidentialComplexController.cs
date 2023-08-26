using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyDimashAngular.Data;
using PropertyDimashAngular.Models;
using PropertyDimashAngular.Services;

namespace PropertyDimashAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentialComplexController : ControllerBase
    {
        private readonly IResidentialComplexService _residentialComplexService;

        public ResidentialComplexController(IResidentialComplexService residentialComplexService)
        {
            _residentialComplexService = residentialComplexService;
        }

        [HttpGet]
        public IEnumerable<ResidentialComplex> Get()
        {
            return _residentialComplexService.GetResidentialComplexList();
        }

        [HttpGet("{id}")]
        public ActionResult<ResidentialComplex> Get(string id)
        {
            var residentialComplex = _residentialComplexService.GetResidentialComplexById(id);

            if(residentialComplex == null)
            {
                return NotFound();
            }

            return Ok(residentialComplex);
        }

        [HttpPost]
        public ActionResult<ResidentialComplex> Post(ResidentialComplex residentialComplex)
        {
            _residentialComplexService.CreateResidentialComplex(residentialComplex);
            return CreatedAtAction("Post", new { id = residentialComplex.Id }, residentialComplex);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if(id == null)
            {
                return BadRequest("Not a valid residential complex id");
            }

            var residentialComplex = _residentialComplexService.GetResidentialComplexById(id);

            if(residentialComplex == null)
            {
                return NotFound();
            }

            _residentialComplexService.DeleteResidentialComplex(residentialComplex);
            return NoContent();
        }
    }
}
