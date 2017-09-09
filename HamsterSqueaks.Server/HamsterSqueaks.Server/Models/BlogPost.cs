using System;

namespace HamsterSqueaks.Server.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string TitlePictureUrl { get; set; }
        public string Content { get; set; }

        public TimeSpan EstimatedReadTime { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? Updated { get; set; }
        public string UrlSlug { get; set; }

        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
