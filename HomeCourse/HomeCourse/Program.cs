using HomeCourse.Services.Interface;
using HomeCourse.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(typeof(ICurso), new CursoRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IProfesor), new ProfesorRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICarritoDeCompras), new CarritoDeComprasRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IUsuario), new UsuarioRepository()));

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
}); //Agregar sesiones al proyecto

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pagina}/{action=Index}/{id?}");

app.Run();
