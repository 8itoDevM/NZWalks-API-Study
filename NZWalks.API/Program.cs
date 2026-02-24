using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NZWalksDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

var app = builder.Build();

if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
