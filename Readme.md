# Clean Architecture - Minimal Api 

## Domain Layer
- DomainEvents
- Entities
- Enums
- Errors
- Exceptions
- Primitives
- Repositories
- Shared
- ValueObjects

## Application Layer
- Abstrations (Repository)
- Dtos
- Api Business Logic (Ex: Posts): CQRS and Mediatr
  - Commands
  - CommandHandlers
  - Queries
  - QueryHandlers
- Security. Replace with stronger methods
- Settings (Typed Config, appsettings.json)

DependencyInjection.cs/AssemblyReference.cs

## Infraestructure Layer
- Database Context
- Repositories
- Services
- BackgroundJobs

DependencyInjection.cs/AssemblyReference.cs

## Presentation Layer
- Abstractions
- Contracts
- Middleware
  - ExceptionHandlingMiddleware
- Configurations
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