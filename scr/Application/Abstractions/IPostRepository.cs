using Domain.Entites;

namespace Application.Abstractions;
public interface IPostRepository
{
    Task<ICollection<PostEntity>> GetAllPosts();
    Task<PostEntity?> GetPost(int postId);
    Task<PostEntity> CreatePost(PostEntity toCreate);
    Task<PostEntity> UpdatePost(int postId, string? updatedContent);
    Task DeletePost(int postId);
}
