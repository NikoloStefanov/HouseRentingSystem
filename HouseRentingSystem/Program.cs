using HouseRentingSystem.Infrastructurea.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationsDbContext(builder.Configuration);
builder.Services.AddApplicationsIdentity(builder.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews(options => 
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationsServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    //app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name:"House Details",
        pattern:"/House/Details/{id}/{information}",
        defaults: new { Controller = "House", Action = "Details" }
        );
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});


await app.RunAsync();
