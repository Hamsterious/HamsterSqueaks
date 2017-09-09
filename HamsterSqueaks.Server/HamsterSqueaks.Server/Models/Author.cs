using System;
using System.Collections.Generic;

namespace HamsterSqueaks.Server.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string PenName { get; set; }

        public Guid UserId { get; set; }
        public virtual HamsterSqueaksUser User { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
