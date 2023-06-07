using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using MusicManaApi.Data;

var builder = WebApplication.CreateBuilder(args);
var bder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews().AddNewtonsoftJson();

var config = bder.Build();
string connectionSting = config.GetConnectionString("Connections") ?? "Default";

string mySqlVersion = "8.0.32";
var serverVersion = new MySqlServerVersion(new Version(mySqlVersion));
builder.Services.AddDbContextPool<AppDbContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString("Connections"), new MySqlServerVersion(serverVersion)));

//PM > Scaffold - DbEntity - ProviderName "System.Data.SqlClient" - ConnectionString "Server=localhost;Database=;Uid=root;Pwd=239889;Integrated Security=True" - OutputDirectory "Models" - Namespace "MusicMana.Models"
//Scaffold-DbContext "Server=.;Database=music_mana;User Id=root;Password=239889;Security=True" MySql.Data.EntityFrameworkCore -OutputDir "Models" -Context "AppDbContext" -Namespace "MusicMana.Models"
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