using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PropertyDimashAngular.Data;
using PropertyDimashAngular.Models;
using PropertyDimashAngular.Services;

namespace PropertyDimashAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext _context;

        public NewsController(INewsService newsService, UserManager<ApplicationUser> user, ApplicationDbContext context)
        {
            _newsService = newsService;
            userManager = user;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<News> Get()
        {
            return _newsService.GetNewsList();
        }

        [HttpGet("{id}")]
        public ActionResult<News> Get(string id)
        {
            var news = _newsService.GetNewsById(id);

            if(news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        [HttpPost]
        public ActionResult<News> Post(News news)
        {
            //news.User = _context.Users.FirstOrDefault(d => d.Id == news.UserId);
            _newsService.CreateNews(news);
            return CreatedAtAction("Post", new { id = news.Id }, news);
        }

        [HttpPut]
        public IActionResult Put(string id, News news)
        {
            if(id != news.Id)
            {
                return BadRequest("Not a valid news id");
            }

            _newsService.UpdateNews(news);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if(id == null)
            {
                return BadRequest("Not a valid news id");
            }

            var news = _newsService.GetNewsById(id);

            if(news == null)
            {
                return NotFound();
            }

            _newsService.DeleteNews(news);
            return NoContent();
        }
    }
}
