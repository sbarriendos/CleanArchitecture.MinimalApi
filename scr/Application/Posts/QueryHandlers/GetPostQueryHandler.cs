using Application.Abstractions;
using Application.Dtos;
using Application.Posts.Queries;
using MediatR;

namespace Application.Posts.QueryHandlers;
internal class GetPostQueryHandler(IPostRepository postRepository) : IRequestHandler<GetPostQuery, PostDto>
{
    public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        return await postRepository.GetPost(request.PostId) ?? throw new NullReferenceException($"Post {request.PostId} not found");
    }
}
