using Domain.Models;
using MediatR;

namespace Application.Posts.Queries;
public class GetAllPostQuery : IRequest<ICollection<Post>>
{
}