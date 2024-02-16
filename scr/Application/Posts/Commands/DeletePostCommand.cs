using MediatR;

namespace Application.Posts.Commands;
public class DeletePostCommand : IRequest
{
    public int PostId { get; set; }
}