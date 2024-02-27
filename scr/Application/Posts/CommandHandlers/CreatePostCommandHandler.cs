using Application.Abstractions;
using Application.Dtos;
using Application.Posts.Commands;
using Domain.Entites;
using MediatR;

namespace Application.Posts.CommandHandlers;
public class CreatePostCommandHandler(IPostRepository postRepository) : IRequestHandler<CreatePostCommand, PostDto>
{
    public async Task<PostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        PostEntity newPost = new()
        {
            Content = request.PostContent,
            DateCreated = DateTime.Now,
            LastModified = DateTime.Now
        };

        PostEntity created = await postRepository.CreatePost(newPost);

        return new PostDto()
        {
            Id = created.Id,
            Content = created.Content,
            DateCreated = created.DateCreated,
            LastModified = created.LastModified
        };
    }
}
