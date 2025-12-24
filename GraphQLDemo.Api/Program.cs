using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Data.Repositories;
using GraphQLDemo.Api.GraphQL.DataLoaders;
using GraphQLDemo.Api.GraphQL.Mutations;
using GraphQLDemo.Api.GraphQL.Queries;
using GraphQLDemo.Api.GraphQL.Resolvers;
using GraphQLDemo.Api.Products.Commands.CreateProduct;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CarvedRockDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("CarvedRock")));
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductReviewRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateProductCommand>());

builder.Services.AddScoped<ProductReviewsByProductIdDataLoader>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<ProductQuery>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<ProductMutation>()
    .AddTypeExtension<ProductReviewMutation>()
    .AddTypeExtension<ProductResolvers>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
