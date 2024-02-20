using DataAccess;
using GruppenFrallasApiSamtDb.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ElevDb");

builder.Services.AddDbContext<ElevDbContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    }
);

var app = builder.Build();
app.MapElevEndpoints();
app.Run();


