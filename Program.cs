using AlgorithmatENMMVCCore;
using AlgorithmatENMMVCCore.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using SharpVision.COMMON.COMMONDataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
} );
builder.Services.AddSignalR();
//builder.Services.AddHostedService<AlgHubService>();
builder.Services.AddSingleton<MessageQueue>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<WebHelpers>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(30); // Set cookie expiration
    });
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Set timeout as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();
WebHelpers.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
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
app.UseSession();

app.MapControllers();
app.UseAuthorization();
app.MapHub<AlgorithmatENMMVCCore.Hubs.AlgHub>("/algHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Service}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=BufferMeasureAPI}/{action=GetMeasureGroup}/{objValue?}");

app.Run();
