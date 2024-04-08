using labPWSI.DataContext;
using labPWSI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddDbContext<CoreStudentsContext>(options => options.UseLazyLoadingProxies()
.UseSqlServer(builder.Configuration.GetConnectionString("StudentContext")));

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddSwaggerGen();

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<CoreStudentsContext>();
context.Database.EnsureCreated();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
