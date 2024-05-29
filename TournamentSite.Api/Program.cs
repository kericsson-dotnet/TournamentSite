using Microsoft.EntityFrameworkCore;
using TournamentSite.Api.Extensions;
using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;
using TournamentSite.Data.Data;
using TournamentSite.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TournamentSiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TournamentSiteContext") ?? throw new InvalidOperationException("Connection string 'TournamentSiteContext' not found.")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IRepository<Game>, GameRepository>();
builder.Services.AddScoped<IUoW, UoW>();

builder.Services.AddAutoMapper(typeof(TournamentSiteMappings));

var app = builder.Build();
await app.SeedDataAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

