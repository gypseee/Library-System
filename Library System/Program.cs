using Library_System.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// 
//builder.Services.AddSwaggerGen();

//
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibrarySystem", Version = "v1" });
});
//



//injecting DbContext class
builder.Services.AddDbContext<LmDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LibaryManagementConnectionString"))
);



//to Allow CROS
builder.Services.AddCors(p=> p.AddPolicy("corspolicy", build=>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();

    //
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibrarySystem");
    });

    //
}

//CROS
 app.UseCors("corspolicy");
//

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
