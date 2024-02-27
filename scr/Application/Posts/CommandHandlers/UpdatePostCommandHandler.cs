using Application.Abstractions;
using Application.Dtos;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandHandlers;
public class UpdatePostCommandHandler(IPostRepository postRepository) : IRequestHandler<UpdatePostCommand, PostDto>
{
    public async Task<PostDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        PostDto newPost = await postRepository.UpdatePost(request.PostId, request.PostContent);

        return await postRepository.CreatePost(newPost);
    }
}