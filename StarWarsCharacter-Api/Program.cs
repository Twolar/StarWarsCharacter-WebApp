using StarWarsCharacter_Api.Data;
using StarWarsCharacter_Api.Helpers;
using StarWarsCharacter_Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<ICharacterRepository, StarWarsCharacterRepository>();
builder.Services.AddScoped<ICharacterMapper, CharacterMapper>();
builder.Services.AddHttpClient();

// Controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();

// TODO: Documentation - Add schemas for request and response models