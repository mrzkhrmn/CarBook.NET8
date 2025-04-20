using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Post()
        {
            Comments = new HashSet<Comment>();
        }
    }
}
