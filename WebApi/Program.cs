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

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IRepositoryBL, RepositoryBL>();

//builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<IJwtService, JwtService>();//?


builder.Services.AddScoped<IRepositoryService, RepositoryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//https://maherz.medium.com/how-to-generate-self-signed-certificates-and-configure-net-core-api-bf4b676c9979
//MUST INSTALL BEFORE USE
//?
//SELF-SIGNED SSL 
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.HttpsPort = 5001;
    //options.ClientCertificateMode = ClientCertificateMode.AllowCertificate;//?
    //options.ServerCertificate = new X509Certificate2("mycert.crt");//?
//});



var app = builder.Build();

//app.UseHttpsRedirection();//FOR USE SELF-SIGNED SSL 


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();//?for middleware

app.MapControllers();

//MY
app.UseRouting();


//Global Cors Policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//JWT auth middleware
//TBC app.UseMiddleware<JwtMiddleware>();
app.UseEndpoints(x => x.MapControllers());


app.Run();
