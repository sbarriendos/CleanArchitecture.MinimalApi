using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers;
public class CreatePostCommandHandler(IPostRepository postRepository) : IRequestHandler<CreatePostCommand, Post>
{
    public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        Post newPost = new()
        {
            Content = request.PostContent
        };

        return await postRepository.CreatePost(newPost);
    }
}
