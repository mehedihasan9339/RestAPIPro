using Microsoft.AspNetCore.Mvc;
using RestAPIPro.Models;
using Microsoft.OpenApi.Models;
using System.IO;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product API",
        Version = "v1",
        Description = "A simple API to manage products (version 1.0)",
    });
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Product API",
        Version = "v2",
        Description = "A versioned API to manage products (version 2.0)",
    });

    // Include XML comments in Swagger UI
    var xmlFile = Path.Combine(AppContext.BaseDirectory, "RestAPIPro.xml");
    options.IncludeXmlComments(xmlFile);
});

var app = builder.Build();

// Enable Swagger and Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Product API v2");
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
