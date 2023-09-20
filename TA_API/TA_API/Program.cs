using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Net;
using Newtonsoft.Json.Serialization;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//configure logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tangent",
        Version = "v1",
        Description = "Solve",
        Contact = new OpenApiContact
        {
            Name = "Olu",
            Email = "Joshmann411@gmail.com",
            Url = new Uri("https://www.example.com/contact"),
        },
    });
});


//extract DB connection string
var mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");

//configure DB to use DB context
//builder.Services.AddDbContextPool<MaiExpDbContext>(options =>
//options.UseMySql(
//    mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

//Enale CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});




//permit json serialization
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IActivity, ActivityRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    // Optionally, you can set the Swagger UI root page to the Swagger endpoint
    c.RoutePrefix = string.Empty; // Swagger will be available at the root URL
                                  // c.RoutePrefix = "swagger"; // Swagger will be available at /swagger
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Monitor}/{action=GetCurrentEnvironment}/{id?}");
});

app.Run();

