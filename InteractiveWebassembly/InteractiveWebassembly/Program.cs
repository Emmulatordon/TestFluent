using InteractiveWebassembly.Client.Pages;
using InteractiveWebassembly.Components;
using InteractiveWebassembly.Components.Layout;
using Microsoft.FluentUI.AspNetCore.Components;
using InteractiveWebassembly.Client.Layout;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode().AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(InteractiveWebassembly.Client._Imports).Assembly);

app.Run();
