

using VolleyballClubProject.Core.Interfaces;
using VolleyballClubProject.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonServices>();

var app = builder.Build();




app.MapGet("/", () => "Hello World!");

app.Run();
