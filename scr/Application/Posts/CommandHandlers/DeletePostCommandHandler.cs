using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandHandlers;
public class DeletePostCommandHandler(IPostRepository postRepository) : IRequestHandler<DeletePostCommand>
{
    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        await postRepository.DeletePost(request.PostId);
    }
}
