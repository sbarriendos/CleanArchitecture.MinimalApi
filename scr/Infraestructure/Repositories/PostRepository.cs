using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;
public class PostRepository(SocialDbContext db) : IPostRepository
{
    public async Task<Post> CreatePost(Post toCreate)
    {
        toCreate.DateCreated = DateTime.Now;
        toCreate.LastModified = DateTime.Now;
        db.Posts.Add(toCreate);
        await db.SaveChangesAsync();
        return toCreate;
    }

    public async Task DeletePost(int postId)
    {
        Post? post = await db.Posts.FirstOrDefaultAsync(p => p.Id == postId);

        if (post is null)
            return;

        await db.SaveChangesAsync();
    }

    public async Task<ICollection<Post>> GetAllPosts()
    {
        return await db.Posts.ToListAsync();
    }

    public async Task<Post?> GetPost(int postId)
    {
        return await db.Posts.FirstOrDefaultAsync(p => p.Id == postId);
    }

    public async Task<Post> UpdatePost(int postId, string? updatedContent)
    {
        Post post = await db.Posts.FirstOrDefaultAsync(p => p.Id == postId)
            ?? throw new NullReferenceException($"Cannot Update post {postId}. Post not found in database");

        post.LastModified = DateTime.Now;
        post.Content = updatedContent;

        await db.SaveChangesAsync();
        return post;
    }
}
