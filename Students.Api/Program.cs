using Students.Infrastructure.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MediaTr
builder.Services.AddMediatR(mt => mt.RegisterServicesFromAssemblies(Assembly.Load("Students.Application")));

//AutoMapper
builder.Services.AddAutoMapper(Assembly.Load("Students.Application"), Assembly.Load("Students.Domain"));

//Persistence
builder.Services.AddPersistence(config).AddDomainServices();

//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .WithMethods("POST", "GET", "PUT", "DELETE");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();