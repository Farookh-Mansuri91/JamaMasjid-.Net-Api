using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.Login.Handlers;
using SunniNooriMasjidAPI.Features.MasjidCommittee.Handlers;
using SunniNooriMasjidAPI.Features.MasjidGullak.Handlers;
using SunniNooriMasjidAPI.Features.MasjidIncomeExpense.Handlers;
using SunniNooriMasjidAPI.Features.SadqaMember.Handlers;
using SunniNooriMasjidAPI.Features.VillageMember.Handlers;
using SunniNooriMasjidAPI.Features.YearlyExpenses.Handlers;
using SunniNooriMasjidAPI.Features.YearlyIncome.Handlers;
using SunniNooriMasjidAPI.Interfaces;
using SunniNooriMasjidAPI.Interfaces.ILoginService;
using SunniNooriMasjidAPI.Interfaces.IMasjidCommittee;
using SunniNooriMasjidAPI.Interfaces.IMasjidGullak;
using SunniNooriMasjidAPI.Interfaces.IMasjidIncomeExpense;
using SunniNooriMasjidAPI.Interfaces.ISadqaMember;
using SunniNooriMasjidAPI.Interfaces.IVillageMember;
using SunniNooriMasjidAPI.Interfaces.IYearlyExpense;
using SunniNooriMasjidAPI.Interfaces.IYearlyIncome;
using SunniNooriMasjidAPI.Repositories;
using SunniNooriMasjidAPI.Services.MasjidCommitteeService;
using SunniNooriMasjidAPI.Services.MasjidGullakService;
using SunniNooriMasjidAPI.Services.MasjidIncomeExpenseService;
using SunniNooriMasjidAPI.Services.SadqaMemberService;
using SunniNooriMasjidAPI.Services.VillageMemberService;
using SunniNooriMasjidAPI.Services.YearlyExpenseService;
using SunniNooriMasjidAPI.Services.YearlyIncomeService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<SunniNooriMasjidDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31))));

// Add MediatR
builder.Services.AddMediatR(typeof(GetGullakQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(AddGullakCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateGullakCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(GetAllSadqaMembersQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetSadqaMembersQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetAllVillageMemberQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetCommitteeMemberQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetVillageMasjidYearlyIncomeQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetAllYearlyExpenseQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetLoginQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetYearlyIncomeExpenseQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetVillageMembersPaymentQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetVillageMohallaQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(AddSadqaMemberCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(AddSadqaPaymentCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateSadqaMemberCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateSadqaPaymentCommandHandler).Assembly); 
builder.Services.AddMediatR(typeof(AddVillageMemberCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(AddPaymentCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateVillageMemberCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdatePaymentCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(AddMasjidYearlyIncomeCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateMasjidYearlyIncomePaymentHandler).Assembly);


// Add Services
builder.Services.AddScoped<IMasjidGullakService, MasjidGullakService>();
builder.Services.AddScoped<ISadqaMemberService,SadqaMemberService>();
builder.Services.AddTransient<IVillageMemberService,VillageMemberService>();
builder.Services.AddTransient<IMasjidIncomeExpenseService,MasjidIncomeExpenseService>();
builder.Services.AddTransient<IMasjidCommitteeService, MasjidCommitteeService>();
builder.Services.AddTransient<IYearlyIncomeService, YearlyIncomeService>();
builder.Services.AddTransient<IYearlyExpenseService, YearlyExpenseService>();
builder.Services.AddTransient<ILoginService, LoginService>();


// Add Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add Controllers
builder.Services.AddControllers();
var allowedOrigins = new string[]
{
    "http://localhost:3000",
    "http://localhost:3001",
    "http://localhost:3002",
    "https://www.noorimasjidghanghori.com",
    "https://api.noorimasjidghanghori.com"
};
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins(allowedOrigins) // Add your frontend origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Noori Masjid API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by your token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "YourIssuer",
            ValidAudience = "YourAudience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5c6cd672f207b15e7a1bc097263cf38da8e8651e552c1d45cd15b547c0c205a4"))
        };
    });
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminRole", policy =>
//        policy.RequireClaim("Role", "Other"));
//});

// Build App
var app = builder.Build();


    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sunni Noori Masjid API v1");
        c.RoutePrefix = "swagger"; // Swagger UI at the root URL
        c.DocumentTitle = "Sunni Noori Masjid API Documentation";
        c.DisplayRequestDuration();
    });
// Use CORS middleware
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
