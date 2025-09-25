using System.Reflection;
using ChallangeMottu.Application;
using ChallangeMottu.Infrastructure;
using ChallangeMottu.Application.Mappings;
using ChallangeMottu.Application.Validators;
using FluentValidation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateMotoDtoValidator>();
// builder.Services.AddFluentValidationAutoValidation();
// builder.Services.AddFluentValidationClientsideAdapters();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration["Swagger:Title"] ?? "MotoMap - API",
        Version = "v1",
        Description =
            "API para gerenciamento de motos no pátio da Mottu - " + DateTime.Now.Year + "<br/><br/>" +
            "Integrantes:<br/>" +
            "- Eduardo Barriviera (RM555309) - https://github.com/edu1805<br/>" +
            "- Thiago Freitas (RM556795) - https://github.com/thiglfa<br/>" +
            "- Bruno Centurion Fernandes (RM556531) - https://github.com/brunocenturion"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    swagger.IncludeXmlComments(xmlPath);
    swagger.EnableAnnotations();
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(MotoProfile), typeof(LocalizacaoAtualProfile));

// --- Registrar camadas via DI ---
builder.Services.AddInfrastructure(builder.Configuration); // DbContext + Repositories
builder.Services.AddApplication(); // Services (MotoService, LocalizacaoAtualService, etc.)

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();