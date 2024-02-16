using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers;
public class GetAllPostQueryHandler(IPostRepository postRepository) : IRequestHandler<GetAllPostQuery, ICollection<Post>>
{
    public async Task<ICollection<Post>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {
        return await postRepository.GetAllPosts();
    }
}