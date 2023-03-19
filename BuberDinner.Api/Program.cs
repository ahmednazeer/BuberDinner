using BuberDinner.Application.Heplers;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Heplers;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.RegisterApplicationServices();
    builder.Services.RegisterInfrastructureServices();
    builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.JwtSettingsSectionName));
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}