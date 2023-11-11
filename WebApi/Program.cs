using System.Data;
using Base.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnection>(new MySqlConnection("server=localhost;database=apheleontotem;user=root"));
//Inyecciones de dependencias
builder.Services.AddScoped<IUserServices, UserManager>();

builder.Services.AddScoped<IUserDal, DpUserDal>();
builder.Services.AddScoped<IAdministradorDal, DpAdministradorDal>();
builder.Services.AddScoped<IDocenteDal, DpDocenteDal>();
builder.Services.AddScoped<IEstudianteDal, DpEstudianteDal>();
builder.Services.AddScoped<IOperadorDal, DpOperadorDal>();
builder.Services.AddScoped<IAuthServices, AuthManager>();
builder.Services.AddScoped<ICoordenadasDal, DpCoordenadasDal>();
builder.Services.AddScoped<ITieneDal, DpTieneDal>();
builder.Services.AddScoped<IGroupDal, DpGrupoDal>();



builder.Services.AddScoped<ICursoDal, DpCursosDal>();
builder.Services.AddScoped<ICursoServices, CursoManager>();
builder.Services.AddScoped<IGroupServices, GroupManager>();
builder.Services.AddScoped<IEstudia_en, DpEstudiaEn>();
builder.Services.AddScoped<IGrupoCursoMateriaDal, DpGrupoCursoMateriaDal>();
// builder.Services.AddScoped<IMateriaServices, MateriaManager>();
builder.Services.AddScoped<ICursoMateria, DpCursoMateria>();
builder.Services.AddScoped<IMateriaDal, DpMateriasDal>();
// builder.Services.AddScoped<IUbicationServices, UbicationManager>();
// builder.Services.AddScoped<IUbicationDal, EfUbicacionDal>();
// builder.Services.AddScoped<IHorariosServices, HorarioManager>();
// builder.Services.AddScoped<IHorarioDal, EfHorarioDal>();

// builder.Services.AddScoped<IHorarioMateriaDal, EfHorarioMateriaDal>();
// builder.Services.AddScoped<IPlanosDal, EfPlanosDal>();
// builder.Services.AddScoped<IPlanosServices, PlanosManager>();


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
