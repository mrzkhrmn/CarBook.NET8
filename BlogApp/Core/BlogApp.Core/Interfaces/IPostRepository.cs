using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Interfaces
{
    public interface IPostRepository: IRepository<Post>
    {
        Task<Post> GetPostWithCommentsAsync(int id);
        Task<IReadOnlyList<Post>> GetPostsByUserIdAsync(int userId);
    }
}
