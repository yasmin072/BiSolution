using BIApplication.Application.services;
using BIApplication.Core.interfaces;
using BIApplication.Core.Interfaces;
using BIApplication.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Charger la chaîne de connexion depuis appsettings.json
var cubeConnectionString = builder.Configuration.GetConnectionString("CubeConnection");

// Add services to the container
builder.Services.AddScoped<ICubeRepository>(provider => 
    new CubeRepository(cubeConnectionString));
builder.Services.AddScoped<IGlobalAnalysisService, GlobalAnalysisService>();
builder.Services.AddScoped<IProductAnalysisService, ProductAnalysisService>();
builder.Services.AddScoped<ITerritoryService,TerritoryService >();
builder.Services.AddScoped<ISalesReasonService,SalesReasonService >();
builder.Services.AddScoped<IOrdersService,OrderService >();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurer CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontends", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Utiliser CORS
app.UseCors("AllowFrontends");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();