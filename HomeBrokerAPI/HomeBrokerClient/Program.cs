using HomeBrokerClient.Models.Repositories;
using HomeBrokerClient.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IOrdemService, OrdemService>();
builder.Services.AddScoped<IOrdemRepository, OrdemRepository>();

builder.Services.AddScoped<IOfertaService, OfertaService>();
builder.Services.AddScoped<IOfertaRepository, OfertaRepository>();

builder.Services.AddScoped<ICarteiraService, CarteiraService>();
builder.Services.AddScoped<ICarteiraRepository, CarteiraRepository>();

builder.Services.AddScoped<IInvestidorService, InvestidorService>();
builder.Services.AddScoped<IInvestidorRepository, InvestidorRepository>();

builder.Services.AddScoped<ITarifaService, TarifaService>();
builder.Services.AddScoped<ITarifaRepository, TarifaRepository>();

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
