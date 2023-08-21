global using API_ENTITY_FRAMEWORK.Repository;
using API_ENTITY_FRAMEWORK.Context;
using API_ENTITY_FRAMEWORK.Services.Destino_Service;
using API_ENTITY_FRAMEWORK.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDestinosServices, DestinosService>();

//builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<BancoDestinosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DestinoConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
