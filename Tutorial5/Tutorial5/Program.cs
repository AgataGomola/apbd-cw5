using Tutorial5.Repositories;
using Tutorial5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Dodanie kontrolerów
builder.Services.AddControllers();
builder.Services.AddScoped<IAnimalsRepositories, AnimalsRepository>();
builder.Services.AddScoped<IAnimalsService, AnimalsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapowanie
app.MapControllers();

app.Run();
