using JwtAuthentification.Infrastructure.DependencyInjection;
using JwtAuthentification.Infrastructure.Helpers;
using JwtAuthentification.Infrastructure.Options;
using JwtAuthentification.Services.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfiguredSwagger();

builder.Services.Configure<JwtSettingOptions>(builder.Configuration.GetJwtSettingSection());

JwtSettingOptions jwtOptions = builder.Configuration.GetJwtSettingOptions();
builder.Services.AddJwtAuthentication(jwtOptions);

builder.Services.AddScoped<IIdentityService, IdentityService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
