using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string PenName { get; set; }
        public Guid UserId { get; set; }
        public virtual HamsterSqueaksUser User { get; set; }
    }
}
