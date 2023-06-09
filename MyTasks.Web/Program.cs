using MyTasks.Application.Interfaces;
using MyTasks.Application.Services;
using MyTasks.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var cosmosConnectionString = builder.Configuration.GetConnectionString("CosmosDB");
var databaseName = builder.Configuration.GetValue<string>("CosmosDB:DatabaseName");
var containerName = builder.Configuration.GetValue<string>("CosmosDB:ContainerName");
builder.Services.AddSingleton<CosmosDbContext>(_ => new CosmosDbContext(cosmosConnectionString, databaseName, containerName));

builder.Services.AddScoped<IServiceTasks, ServiceTasks>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
