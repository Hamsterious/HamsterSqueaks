using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? LastEdit { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
