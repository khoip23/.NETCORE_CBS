using dotnet03_web_blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//DI service http
builder.Services.AddHttpClient();

//DI các service tự tạo
builder.Services.AddScoped<StateNumberService>();
builder.Services.AddScoped<Burger>();
builder.Services.AddScoped<BurgerStateService>();
builder.Services.AddScoped<ProductStateService>();
builder.Services.AddScoped<ProductResfulService>();
builder.Services.AddScoped<RoomService>();

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

app.MapBlazorHub();
app.MapHub<RoomHub>("/roomhub");
app.MapFallbackToPage("/_Host");

app.Run();
