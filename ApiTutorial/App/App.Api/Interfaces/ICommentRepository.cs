using App.Api.Dtos;
using App.Api.Models;

namespace App.Api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id, Comment commentDto);
        Task<Comment?> DeleteAsync(int id);
    }
}
