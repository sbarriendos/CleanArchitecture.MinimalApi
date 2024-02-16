using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers;
internal class GetPostQueryHandler(IPostRepository postRepository) : IRequestHandler<GetPostQuery, Post>
{
    public async Task<Post> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        return await postRepository.GetPost(request.PostId) ?? throw new NullReferenceException($"Post {request.PostId} not found");
    }
}
