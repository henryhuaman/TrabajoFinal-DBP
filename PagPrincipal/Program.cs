using PagPrincipal.Services.Interface;
using PagPrincipal.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(typeof(ICurso), new CursoRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IProfesores), new ProfesoresRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICliente), new ClienteRepository()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pagina}/{action=Index}/{id?}");

app.Run();
