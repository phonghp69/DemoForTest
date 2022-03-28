using backend.Interfaces;
using backend.Services;
using backend.Authorization;
using System.Text.Json.Serialization;
using backend.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("name=ConnectionStrings:MyConnection").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IAssetService, AssetService>();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// configure strongly typed settings object
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));

//Services
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();