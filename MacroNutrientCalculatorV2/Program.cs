using MacroNutrientCalculatorV2.Services;
using MacroNutrientCalculatorV2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MacronutrientDBContextConnection") ?? throw new InvalidOperationException("Connection string 'MacronutrientDBContextConnection' not found.");

builder.Services.AddDbContext<MacronutrientDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MacroNutrientUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MacronutrientDBContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped<CalculatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Map controllers to handle incoming requests.
    endpoints.MapRazorPages();
});
app.Run();

