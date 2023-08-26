using Microsoft.EntityFrameworkCore;
using PropertyDimashAngular.Data;
using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Services
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _context;

        public NewsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<News> GetNewsList()
        {
            return _context.News.Include(d => d.User).ToList();
        }
        
        public News GetNewsById(string id)
        {
            return _context.News.Include(d => d.User).FirstOrDefault(d => d.Id == id);
        }

        public News CreateNews(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
            return news;
        }

        public void UpdateNews(News news)
        {
            _context.News.Update(news);
            _context.SaveChanges();
        }

        public void DeleteNews(News news)
        {
            _context.News.Remove(news);
            _context.SaveChanges();
        }
    }
}
