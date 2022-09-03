global using Microsoft.EntityFrameworkCore;
using GameWatchAPI.Data;
using GameWatchAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using GameWatchAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager _config = builder.Configuration; //allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddControllers(opt =>
{
   /* var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));*/
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GameWatchDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyMethod().AllowCredentials().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddControllers()
    .AddNewtonsoftJson();


builder.Services.AddIdentityServices(_config);


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<FaturaService>();
builder.Services.AddTransient<CmimorjaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

/*app.UseAuthentication();*/
app.UseAuthorization();

app.MapControllers();

app.Run();
