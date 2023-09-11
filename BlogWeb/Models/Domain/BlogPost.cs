namespace BlogWeb.Models.Domain
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string Author { get; set; }
    }
}
