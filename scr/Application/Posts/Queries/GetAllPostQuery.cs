using Application.Dtos;
using MediatR;

namespace Application.Posts.Queries;
public class GetAllPostQuery : IRequest<ICollection<PostDto>>
{
}