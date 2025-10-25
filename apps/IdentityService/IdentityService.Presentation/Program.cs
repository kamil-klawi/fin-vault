using IdentityService.Application.Services.AuthService;
using IdentityService.Application.Services.ResetPassword;
using IdentityService.Application.Services.VerificationCode;
using IdentityService.Infrastructure.Extensions;
using SharedLibrary.Common.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IVerificationCode, VerificationCode>();
builder.Services.AddScoped<IResetPassword, ResetPassword>();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Extensions from my own shared library
app.UseGlobalExceptionHandling();
app.UseRequestTimeLogging();
app.UseCorrelationId();
app.UseSecurityHeaders();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
