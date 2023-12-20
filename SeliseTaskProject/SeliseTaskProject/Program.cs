using BusinessLogicLayer.ApplicationSettingsOptions;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using SeliseTaskProject.Extenstion;
using DataAccessLayer;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Task_Connection")));
//builder.Services.AddDBContext(builder.Configuration);

builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));

builder.Services.AddServiceDependencies();

builder.Services.AddJWT(builder.Configuration);

builder.Services.AddIdentityConfig();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null); ;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors( builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.Run();
