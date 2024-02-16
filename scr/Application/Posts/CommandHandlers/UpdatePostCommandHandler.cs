using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers;
public class UpdatePostCommandHandler(IPostRepository postRepository) : IRequestHandler<UpdatePostCommand, Post>
{
    public async Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        Post newPost = await postRepository.UpdatePost(request.PostId, request.PostContent);

        return await postRepository.CreatePost(newPost);
    }
}