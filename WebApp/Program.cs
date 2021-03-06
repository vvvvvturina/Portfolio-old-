using DataAccess;
using Microsoft.EntityFrameworkCore;
using Misc.Services.EmailService;
using Portfolio.Misc.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<EmailSender>();
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton(builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>());

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddDbContext<Context>(opts =>
    opts.UseSqlServer(builder.Configuration.
        GetConnectionString("sqlConnection")));
builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

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