using StudyCoreAPI.Infrastructure.Classes;
using Microsoft.EntityFrameworkCore;
using StudyCoreAPI;
using StudyCoreAPI.Application.Interfaces;
using StudyCoreAPI.Infrastructure.Classes.Repository;
using StudyCoreAPI.Infrastructure.Classes.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StudyCoreAPIContext>(options => options.UseSqlite(connectionString));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<Account>()
    .AddEntityFrameworkStores<StudyCoreAPIContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Account, string>, AccountRepository>();
builder.Services.AddScoped<IRepository<Workspace, Guid>, WorkspaceRepository>();
builder.Services.AddScoped<IRepository<WorkspaceAccess, Guid>, WorkspaceAccessRepository>();
builder.Services.AddScoped<IRepository<Word, int>, WordRepository>();
builder.Services.AddScoped<IRepository<Book, int>, BookRepository>();
builder.Services.AddScoped<IRepository<Problem, int>, ProblemRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<Account>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();