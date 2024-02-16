using Application.Posts.Commands;
using Application.Posts.Queries;
using Carter;
using Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Presentation.Validators;

namespace WebApi.Modules;

public class PostsModule : CarterModule
{
    public PostsModule()
        : base("/api/posts")
    {
    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", GetPost)
            .WithName("GetPostById");

        app.MapGet("/", GetAllPosts)
            .WithName("GetAllPost");

        app.MapPost("/", CreatePost)
            .AddEndpointFilter<ValidationFilter<Post>>()
            .WithName("CreatePost");

        app.MapPut("/{id}", UpdatePost)
            .AddEndpointFilter<ValidationFilter<Post>>()
            .WithName("UpdatePost");

        app.MapDelete("/{id}", DeletePost)
            .WithName("DeletePost");
    }
    private static async Task<NoContent> DeletePost(IMediator mediator, int id)
    {
        DeletePostCommand deletePost = new() { PostId = id };
        await mediator.Send(deletePost);

        return TypedResults.NoContent();
    }
    private static async Task<IResult> GetPost(IMediator mediator, int id)
    {
        GetPostQuery getPost = new() { PostId = id };
        Post post = await mediator.Send(getPost);

        return TypedResults.Ok(post);
    }
    private static async Task<IResult> GetAllPosts(IMediator mediator)
    {
        GetAllPostQuery getAllPost = new();
        ICollection<Post> posts = await mediator.Send(getAllPost);

        return TypedResults.Ok(posts);
    }
    private static async Task<object> CreatePost(IMediator mediator, Post post)
    {
        CreatePostCommand createPost = new() { PostContent = post.Content };
        Post createdPost = await mediator.Send(createPost);

        return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
    }
    private static async Task<Ok<Post>> UpdatePost(IMediator mediator, Post post, int id)
    {
        UpdatePostCommand updatePost = new() { PostId = id, PostContent = post.Content };
        Post updatedPost = await mediator.Send(updatePost);

        return TypedResults.Ok(updatedPost);
    }

}
