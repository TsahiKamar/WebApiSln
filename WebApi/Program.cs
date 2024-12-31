using WebApi;
using WebApi.BL;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IRepositoryBL, RepositoryBL>();

//builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IJwtService, JwtService>();//?


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

//ORIG CODE app.UseAuthorization();

//ORIG CODE app.MapControllers();

//MY
app.UseRouting();
//Global Cors Policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//JWT auth middleware
app.UseMiddleware<JwtMiddleware>();
app.UseEndpoints(x => x.MapControllers());


app.Run();
