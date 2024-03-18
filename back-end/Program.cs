using System.Text;
using Ioc.Api;
using Ioc.Test;
using Mapper.Adress;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.
    ReadFrom.Configuration(context.Configuration)
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:1234");
});

builder.Services.AddHttpContextAccessor();

if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.ConfigureDBContextTest();

    builder.Services.ConfigureInjectionDependencyRepositoryTest();
    builder.Services.ConfigureInjectionDependencyServiceTest();
}
else
{
    builder.Services.ConfigureDBContext(configuration);
    builder.Services.ConfigureInjectionDependencyRepository();
    builder.Services.ConfigureInjectionDependencyService();
}

builder.Services.AddAutoMapper(typeof(AutoMapperAll));

// Adding Authentication
var validAudience = builder.Configuration["JWT:ValidAudience"];
var validIssuer = builder.Configuration["JWT:ValidIssuer"];
var secret = builder.Configuration["JWT:Secret"];

builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = validAudience,
            ValidIssuer = validIssuer,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])
            )
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "ReactLocal",
      policy => policy.WithOrigins("http://localhost:3006").AllowAnyHeader().AllowAnyMethod()
    );
    options.AddPolicy(
       "React",
     policy => policy.WithOrigins("http://158.178.198.162:3006").AllowAnyHeader().AllowAnyMethod()
   );
    options.AddPolicy(
        "PotShopMobile",
      policy => policy.WithOrigins("http://localhost:2001").AllowAnyHeader().AllowAnyMethod()
    );
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSetting"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Services.AddHttpContextAccessor();

app.UseCookiePolicy();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("ReactLocal");
app.UseCors("React");
app.UseCors("PotShopMobile");
app.MapControllers();

app.Run();

public partial class Program { }

