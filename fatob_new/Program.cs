using fatob_new.Data;
using fatob_new.Interfaces;
using fatob_new.Repository;
using fatob_new.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITravelRepository, TravelRepository>();
builder.Services.AddScoped<IBusRepository, BusRepository>();

builder.Services.AddTransient<ITicketCreatorService, TicketCreatorService>();
builder.Services.AddTransient<IEmailSenderService, EmailSenderService>();

builder.Services.AddDbContext<ApplicationDataContext>
(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    Seed.SeedData(app);
}

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
