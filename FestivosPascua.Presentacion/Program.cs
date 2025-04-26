using FestivosPascua.Presentacion.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngular",
        policy =>
        {
            policy.WithOrigins("https://localhost:7118/api/festivo")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
var configuracion = builder.Configuration;

builder.Services.AgregarDependencias(configuracion);

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

// CORS debe ir antes de Authorization
app.UseCors("PermitirAngular");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
