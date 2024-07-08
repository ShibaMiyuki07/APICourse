using API.Extension;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

//Set the appsettings json
var json = $"appsettings.{env.EnvironmentName}.json";
var config = builder.Configuration;
config.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(json);
builder.Services.ServiceInjection(config);

//Getting allowed origin
var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin!)
                .AllowAnyHeader()
                .AllowAnyMethod();
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

app.UseAuthorization();
app.UseCors("myAppCors");
app.MapControllers();


app.Run();
