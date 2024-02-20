using Application.Posts.Commands;
using Application.Posts.Queries;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Carter;
using Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Presentation.Validators;

namespace WebApi.Modules;

public class PostsModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet("Post")
        .HasDeprecatedApiVersion(new ApiVersion(0.1))
        .HasApiVersion(new ApiVersion(1))
        .ReportApiVersions()
        .Build();

        RouteGroupBuilder group = app.MapGroup("/api/v{version:apiVersion}/posts")
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1);

        group.MapGet("/{id}", GetPost)
            .WithName("GetPostById");

        group.MapGet("/", GetAllPosts)
            .WithName("GetAllPost");

        group.MapPost("/", CreatePost)
            .AddEndpointFilter<ValidationFilter<Post>>()
            .WithName("CreatePost");

        group.MapPut("/{id}", UpdatePost)
            .AddEndpointFilter<ValidationFilter<Post>>()
            .WithName("UpdatePost");

        group.MapDelete("/{id}", DeletePost)
            .WithName("DeletePost");
    }
    private static async Task<IResult> GetPost(ILogger<PostsModule> log, IMediator mediator, int id)
    {
        log.LogInformation("Get Post V1");

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
    private static async Task<NoContent> DeletePost(IMediator mediator, int id)
    {
        DeletePostCommand deletePost = new() { PostId = id };
        await mediator.Send(deletePost);

        return TypedResults.NoContent();
    }
}
