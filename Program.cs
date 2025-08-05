using AlgorithmatENMMVCCore;
using AlgorithmatENMMVCCore.Controllers;
using AlgorithmatENMMVCCore.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.SystemBase;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
} );
if (SysData.Onsite)
{
    builder.Services.AddHostedService<AlgHubService>();
}
if (SysData.BringOnlineData)
{ 
    builder.Services.AddHostedService<AlgGetOnlineService>(); 
}
if (SysData.UploadData)
{
    builder.Services.AddHostedService<AlgUpdateMOStatusService>();
}
builder.Services.AddEndpointsApiExplorer();
 
builder.Services.AddScoped<IManufacturingService, ManufacturingService>();

builder.Services.AddSingleton<MessageQueue>();
builder.Services.AddSignalR();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowOdoo", policy => {
        policy.AllowAnyOrigin()  // Accept from any Odoo Cloud instance
              .AllowAnyMethod()
              .AllowAnyHeader().WithExposedHeaders("*");
               
    });
});
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; // Disables automatic 400 responses
    });

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

// Enable buffering to allow multiple reads of the request body
builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.BufferBody = true;
});

// Disable ALL model validation
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
        options.SuppressMapClientErrors = true;
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
app.UseCors("AllowOdoo");
app.MapControllers();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapHub<AlgorithmatENMMVCCore.Hubs.AlgHub>("/algHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Service}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=BufferMeasureAPI}/{action=GetMeasureGroup}/{objValue?}");
app.MapControllerRoute(
    name: "defaultAPI1",
    pattern: "api/{controller}/{action=GetMeasureGroup}/{objValue?}");

app.Run();
