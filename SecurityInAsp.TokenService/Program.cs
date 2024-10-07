var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region Add Identity Server

builder.Services.AddIdentityServer().AddDeveloperSigningCredential();

#endregion

#region Add MVC

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

#endregion

if (!app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseIdentityServer();
app.UseStaticFiles();
app.UseMvc(route =>
{
    route.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
