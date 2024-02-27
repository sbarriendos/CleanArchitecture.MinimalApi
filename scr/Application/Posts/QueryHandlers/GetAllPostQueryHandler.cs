using Application.Abstractions;
using Application.Dtos;
using Application.Posts.Queries;
using MediatR;

namespace Application.Posts.QueryHandlers;
public class GetAllPostQueryHandler(IMapper mapper, IPostRepository postRepository) : IRequestHandler<GetAllPostQuery, ICollection<PostDto>>
{
    public async Task<ICollection<PostDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {
        var a = await postRepository.GetAllPosts();

        return _mapper.Map<ProductDTO>(product);
    }
}