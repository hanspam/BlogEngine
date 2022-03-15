using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Services.Queries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddMediatR(Assembly.Load("Service.EventHandler"));
builder.Services.AddTransient<IPostQueryService, PostQueryService>();
builder.Services.AddTransient<IUserQueryService, UserQueryService>();
builder.Services.AddTransient<ICommentQueryService, CommentQueryService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole", policy =>
          policy.RequireRole("Administrator", "PowerUser"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
