using HealthChecks.UI.Client;
using InventApplication.API.Middleware;
using InventApplication.Infrastructure.Health;
using InventApplication.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
ServicesRegisterIOC.RegisterService(builder.Services);

#region Health Check
// Add services to the container.
builder.Services.AddHealthChecks()
        .AddCheck<DatabaseHealthCheck>("Database");
#endregion

#region Swagger Config

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InventApp",
        Version = "v1",
        Description = "Inventory Application Learing Demo"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Description = "Please Enter Token",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id="Bearer",
                    Type=ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
#endregion

#region  Cors
var CorsPolicy = "CorsPolicy";
var origins = Configuration.GetSection("CorsAllowedOrigins:Url").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
                      builder =>
                      {
                          builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                          .WithOrigins(origins)
                          .AllowAnyHeader()
                          .AllowCredentials()
                          .AllowAnyMethod();
                      });
});
#endregion

#region JWT Authentication
var secretkey = Encoding.ASCII.GetBytes(Configuration["JwtSettings:SecretKey"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = Configuration["JwtSettings:Audience"],
        ValidIssuer = Configuration["JwtSettings:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(secretkey),
        ClockSkew = TimeSpan.Zero
    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(options =>
{
    if (Convert.ToBoolean(Configuration["AuthorizationSettings:IsDisabled"]))
    {
        options.DefaultPolicy = new AuthorizationPolicyBuilder()
            .RequireAssertion(_ => true)
            .Build();
    }
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
    options.AddPolicy("AdminOrUser", policy =>
    {
        policy.RequireRole("Admin", "User");
    });
});
#endregion

#region Logger 
var path = Configuration["LogSettings:Path"];
var tracePath = Path.Join(path, $"Log_LEADSAPI_{DateTime.Now.ToString("yyyyMMdd")}.txt");
Trace.Listeners.Add(new TextWriterTraceListener(tracePath));
Trace.AutoFlush = true;
#endregion

#region Custom Configurations Swagger
static void ConfigureSwagger(IApplicationBuilder app, IConfiguration configuration)
{
    string? currentEnv = configuration.GetSection("CurrentEnvironment:Environment").Value?.ToLower();
    if (currentEnv != "production" && currentEnv != "staging")
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
#endregion

var app = builder.Build();

app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
ConfigureSwagger(app, Configuration);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseCors(CorsPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
