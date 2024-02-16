using Domain.Models;
using MediatR;

namespace Application.Posts.Queries;

public class GetPostQuery : IRequest<Post>
{
    public int PostId { get; set; }
}