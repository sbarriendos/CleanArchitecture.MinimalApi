# Clean Architecture - Minimal Api 

## Domain Layer
- Models

## Application Layer
- Repository Abstrations
- CQRS and Mediatr
  - Commands
  - CommandHandlers
  - Queries
  - QueryHandlers
- Security. Replace with stronger methods
- Typed Config (appsettings.json)

## Infraestructure Layer
- Database Context
- Repositories

## Presentation Layer
- Middleware
  - ExceptionHandlingMiddleware
- Validators (FluentValidator)

## Web Api
- Modules (Endpoint Definitions using Carter)
- Extensions
  - Implements basic Authentication and Authorization


# Http Request Flow
>Postman Http Post new Post
>EndpointFilter - ***PresentationLayer***.ValidationFilter<Post>
>***WebApi***.MapPost (Post post)
>>new ***ApplicationLayer***.CreatePostCommand
>>mediator.Send(createPostCommand)
>>>***ApplicationLayer***.CreatePostCommandHandler.Handle, Request as CreatePostCommand
>>>***InfraestructureLayer***.PostRepository.CreatePost, Uses Entity Framework to create a Post in DataBase