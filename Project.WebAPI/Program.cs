using Project.WebAPI.Models.Contexts;
using Project.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICacheService, CacheService>();
AddContexts.AddContextForModels(builder);


builder.Services.AddCors(options => options.AddPolicy(name: "PatientOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("PatientOrigins");
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
