using ApiGestionCursos.Repository.IRepository;
using ApiGestionCursos.Repository;
using ApiGestionCursos.Services.IServices;
using ApiGestionCursos.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
