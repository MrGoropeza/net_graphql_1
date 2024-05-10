using API.Application;
using API.Domain;
using API.GraphQL;
using API.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddDomain()
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddGraphQLServices();

var app = builder.Build();

app.UseGraphQL();

app.Run();
