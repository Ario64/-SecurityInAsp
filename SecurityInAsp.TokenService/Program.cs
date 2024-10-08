using IdentityServer8.Test;
using IdentityServerHost.Quickstart;
using IdentityServerHost.Quickstart.UI;
using SecurityInAsp.TokenService;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region Add Identity Server

builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(Config.GetIdentityResources())
    .AddInMemoryClients(Config.GetClients())
    .AddTestUsers(TestUsers.Users);

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
