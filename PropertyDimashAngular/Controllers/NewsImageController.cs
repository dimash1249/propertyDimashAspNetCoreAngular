using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyDimashAngular.Data;
using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsImageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NewsImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<byte[]> Upload(IFormFile file)
        {
            byte[] imageNews;
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                imageNews = stream.ToArray();
                var propertyImage = new PropertyImage
                {
                    Image = imageNews,
                };
                //_context.PropertyImages.Add(propertyImage);
                //_context.SaveChanges();
            }
            return Ok(new { message = imageNews });
        }
    }
}
