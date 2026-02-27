using AutoMapper;
using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NZWalksDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<MappingProfiles>();
});

var app = builder.Build();

if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
