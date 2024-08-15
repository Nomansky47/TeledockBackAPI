using Microsoft.EntityFrameworkCore;
using TeledockBackAPI.Model;
using TeledokBackendAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options=>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
DbInitializer.CreateDb(app);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseSwagger();
app.UseSwaggerUI();
app.MapDefaultControllerRoute();
app.Run();
