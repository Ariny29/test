// This is the MAIN branch comment.
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder .Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddDbContext<LogisticsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Server=localhost;Database=LogisticsDb;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddScoped<IShipmentService, ShipmentService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(); 

app.Run();
