using Vagabond.MVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IDestinationService, DestinationService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5232/"); 
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Travel}/{action=Index}/{id?}");

app.Run();