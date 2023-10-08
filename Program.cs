using product.Services;
using Microsoft.FeatureManagement;
 

var builder = WebApplication.CreateBuilder(args);

//appConfiguration connection string
var connectionString = "Endpoint=https://product-db-sql-server.azconfig.io;Id=MdNN;Secret=JiVfyavSgbnhxsd08ZZRuhPCQxemIhJM8JqyAZesc7g=";

builder.Host.ConfigureAppConfiguration(builder => {
  builder.AddAzureAppConfiguration(
    options => options.Connect(connectionString).UseFeatureFlags()
    
  );
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddFeatureManagement();
builder.Services.AddTransient<IProductService,ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();