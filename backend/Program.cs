using backend.Interfaces;
using backend.Services;
using backend.Authorization;
using System.Text.Json.Serialization;
using backend.Helpers;
using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o =>
            {
                o.AddPolicy("AllowAllRequests", builder => 
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                    );
            });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("name=ConnectionStrings:EFGetStartedConnectionString"));
//builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("name=ConnectionStrings:MyConnection"));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// configure strongly typed settings object
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));

//Services
builder.Services.AddTransient<IJwtUtils, JwtUtils>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllRequests");

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();