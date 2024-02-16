﻿using Domain.Models;

namespace Application.Abstractions;
public interface IPostRepository
{
    Task<ICollection<Post>> GetAllPosts();
    Task<Post?> GetPost(int postId);
    Task<Post> CreatePost(Post toCreate);
    Task<Post> UpdatePost(int postId, string? updatedContent);
    Task DeletePost(int postId);
}
