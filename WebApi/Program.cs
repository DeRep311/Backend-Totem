using Base.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyecciones de dependencias
builder.Services.AddScoped<IUserServices, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IAdministradorDal, EfAdministradorDal>();
builder.Services.AddScoped<IDocenteDal, EfDocenteDal>();
builder.Services.AddScoped<IEstudianteDal, EfEstudianteDal>();
builder.Services.AddScoped<IOperadorDal, EfOperadorDal>();


builder.Services.AddScoped<IAuthServices, AuthManager>();

builder.Services.AddScoped<ICursoServices, CursoManager>();
builder.Services.AddScoped<ICursoDal, EfCursosDal>();
builder.Services.AddScoped<IMateriaServices, MateriaManager>();
builder.Services.AddScoped<ICursoMateria, EfCursoMaterialDal>();
builder.Services.AddScoped<IMateriaDal, EfMateriaDal>();
builder.Services.AddScoped<IUbicationServices, UbicationManager>();
builder.Services.AddScoped<IUbicationDal, EfUbicacionDal>();
builder.Services.AddScoped<IHorariosServices, HorarioManager>();
builder.Services.AddScoped<IHorarioDal, EfHorarioDal>();
builder.Services.AddScoped<IGroupServices, GroupManager>();
builder.Services.AddScoped<IGroupDal, EfGroupDal>();
builder.Services.AddScoped<IHorarioMateriaDal, EfHorarioMateriaDal>();
builder.Services.AddScoped<IPlanosDal, EfPlanosDal>();
builder.Services.AddScoped<IPlanosServices, PlanosManager>();


builder.Services.AddScoped<IUbicationMateriaDal, EfUbicationMateriaDal>();






var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "imagenes");
if (!Directory.Exists(imagePath))
{
    Directory.CreateDirectory(imagePath);
}
 app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(imagePath),
        RequestPath = "/imagenes"
    });
    
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
