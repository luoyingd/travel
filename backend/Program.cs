using System.Security.Cryptography;
using System.Text;
using backend.Controllers;
using backend.Data;
using backend.Filters;
using backend.Repository;
using backend.Service.User;
using backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// log
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new CustomExceptionHandler());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// allow cross origin in dev
builder.Services.AddCors((options) =>
{
    options.AddPolicy("DevCors", (corsBuilding) =>
    {
        corsBuilding.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

// add singleton for interface and implementation here. same instance for the entire app
// 如果是需要每个请求一个实例, 用scoped
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();

// set up authentication of jwt
// frontend need to set Authorization = Bearer {token} in headers
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:token_key").Value
        )),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


// make dapper column mapping
ColumnMapper.SetMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // allow cross origin in dev
    app.UseCors("DevCors");
}

// app.UseHttpsRedirection();

// authentication has to be prior to authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
