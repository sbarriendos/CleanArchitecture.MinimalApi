using Application.Dtos;
using MediatR;

namespace Application.Posts.Commands;
public class UpdatePostCommand : IRequest<PostDto>
{
    public int PostId { get; set; }
    public string? PostContent { get; set; }
}