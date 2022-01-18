using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VicShop;
using VicShop.Api.Common;
using VicShop.Api.Hubs;
using VicShop.Api.Odata;
using VicShop.EF;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration;
configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", VicShopEntityDataModel.GetEdmModel())
    .Select()
    .Expand()
    .OrderBy()
    .SetMaxTop(10)
    .Count()
    .Filter());
builder.Services.AddDbContext<VicShopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<VicShopDbContext>();

// Adding Authentication
var jwtConfig = configuration.GetSection("JWT").Get<JsonWebTokenModel>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = jwtConfig.ValidAudience,
        ValidIssuer = jwtConfig.ValidIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig!.SecretKey))
    };
});
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<DataInitializer>();
builder.Services.AddSignalR();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "MsShop.Api", Version = "v1" });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your valid token Example: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}

        }
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VicShop.Api v1"));
}
PrepareDatabase.InitDatabase(app);
app.UseHttpsRedirection();
app.UseCors(o => o
    .WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .SetIsOriginAllowed(host => true));

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chat"); ;
app.Run();
