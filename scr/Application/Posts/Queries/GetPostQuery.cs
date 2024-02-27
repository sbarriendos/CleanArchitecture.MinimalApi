using Application.Dtos;
using MediatR;

namespace Application.Posts.Queries;

public class GetPostQuery : IRequest<PostDto>
{
    public int PostId { get; set; }
}