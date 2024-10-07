var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region Add Identity Server

builder.Services.AddIdentityServer().AddDeveloperSigningCredential();

#endregion

app.UseIdentityServer();

app.Run();
