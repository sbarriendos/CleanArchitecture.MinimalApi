using Application.Dtos;
using MediatR;

namespace Application.Posts.Commands;
public class CreatePostCommand : IRequest<PostDto>
{
    public string? PostContent { get; set; }
}
