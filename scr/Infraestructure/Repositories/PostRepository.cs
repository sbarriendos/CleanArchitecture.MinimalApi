using Application.Abstractions;
using Application.Dtos;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;
public class PostRepository(SocialDbContext db) : IPostRepository
{
    public async Task<PostEntity> CreatePost(PostEntity toCreate)
    {
        toCreate.DateCreated = DateTime.Now;
        toCreate.LastModified = DateTime.Now;
        db.Posts.Add(toCreate);
        await db.SaveChangesAsync();
        return toCreate;
    }

    public Task<PostDto> CreatePost(PostDto toCreate)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePost(int postId)
    {
        PostEntity? post = await db.Posts.FirstOrDefaultAsync(p => p.Id == postId);

        if (post is null)
            return;

        await db.SaveChangesAsync();
    }

    public async Task<ICollection<PostEntity>> GetAllPosts()
    {
        return await db.Posts.ToListAsync();
    }

    public async Task<PostEntity?> GetPost(int postId)
    {
        return await db.Posts.FirstOrDefaultAsync(p => p.Id == postId);
    }

    public async Task<PostEntity> UpdatePost(int postId, string? updatedContent)
    {
        PostEntity post = await db.Posts.FirstOrDefaultAsync(p => p.Id == postId)
            ?? throw new NullReferenceException($"Cannot Update post {postId}. Post not found in database");

        post.LastModified = DateTime.Now;
        post.Content = updatedContent;

        await db.SaveChangesAsync();
        return post;
    }
}
