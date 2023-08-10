using PropertyDimashAngular.Data;

namespace PropertyDimashAngular.Models
{
    public class News
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageAuthor { get; set; }
        public byte[] ImageNews { get; set; }
        public string NewsType { get; set; }
        public string PublishedDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }

    public class NewsModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageAuthor { get; set; }
        public byte[] ImageNews { get; set; }
    }
}
