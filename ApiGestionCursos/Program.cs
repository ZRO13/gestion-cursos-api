using ApiGestionCursos.Models;
using ApiGestionCursos.Repository;
using ApiGestionCursos.Repository.IRepository;
using ApiGestionCursos.Services;
using ApiGestionCursos.Services.IServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mapster;
using ApiGestionCursos.Mapping;


var builder = WebApplication.CreateBuilder(args);



var dbConnectionString = builder.Configuration.GetConnectionString("ConexionSql");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(dbConnectionString)
    //.UseSeeding((context, _) =>
    //{
    //    var appContext = (ApplicationDbContext)context;
    //    DataSeeder.SeedData(appContext);
    //})
);
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();

builder.Services.AddScoped<IDocenteRepository, DocenteRepository>();
builder.Services.AddScoped<IDocenteService, DocenteService>();

builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMapster();

MapsterConfig.RegisterMappings();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // El puerto exacto que muestra tu consola
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var apiVersioningBuilder = builder.Services.AddApiVersioning(
    option => {         
        option.DefaultApiVersion = new ApiVersion(1, 0);
        option.AssumeDefaultVersionWhenUnspecified = true;
        option.ReportApiVersions = true;
        option.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader("api-version"));
    }
    );

apiVersioningBuilder.AddApiExplorer(option =>
{
    option.GroupNameFormat = "'v'VVV";
    option.SubstituteApiVersionInUrl = true;
});
//builder.Services.AddIdentity<ApplicationUser IdentityRole>()
//.AddEntityFrameworkStores<ApplicationDbContext>()
//.AddDefaultTokenProviders();
var app = builder.Build();
app.UseCors("AllowAngular");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
