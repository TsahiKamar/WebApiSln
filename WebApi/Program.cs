using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;
using WebApi;
using WebApi.BL;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

//Register HttpClient service
builder.Services.AddHttpClient();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddControllers();

builder.Services.AddScoped<IRepositoryBL, RepositoryBL>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IJwtService, JwtService>();

builder.Services.AddScoped<IRepositoryService, RepositoryService>();

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

app.MapControllers();
app.UseRouting();

//Global Cors Policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//JWT Auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseEndpoints(x => x.MapControllers());

app.Run();
