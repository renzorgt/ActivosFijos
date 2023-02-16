using ApiActivosFijos.MySqlContext;
using ApiActivosFijos.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var mySQLConfiguration = new MySqlDbContext(builder.Configuration.GetConnectionString("Conex"));
builder.Services.AddSingleton(mySQLConfiguration);

builder.Services.AddScoped<IActivoFijoRepository,ActivoFijoRepository>();
builder.Services.AddScoped<ITipoRepository, TipoRepository>();

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
