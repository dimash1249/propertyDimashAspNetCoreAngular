using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Services
{
    public interface INewsService
    {
        IEnumerable<News> GetNewsList();
        News GetNewsById(string id);
        News CreateNews(News news);
        void UpdateNews(News news);
        void DeleteNews(News news);
    }
}
