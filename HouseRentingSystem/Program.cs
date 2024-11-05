var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationsDbContext(builder.Configuration);
builder.Services.AddApplicationsIdentity(builder.Configuration);

 builder.Services.AddControllersWithViews();

builder.Services.AddApplicationsServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.RunAsync();
