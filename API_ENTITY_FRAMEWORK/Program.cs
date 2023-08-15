global using API_ENTITY_FRAMEWORK.Repository;
using API_ENTITY_FRAMEWORK.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

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
