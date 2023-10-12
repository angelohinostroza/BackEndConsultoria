using ApiWeb.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using UtilAutomapper;

var builder = WebApplication.CreateBuilder(args);



//CONFIGURACI�N DEL CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "origins",
                      builder =>
                      {
                          //builder.WithOrigins("http://127.0.0.1:5500");
                          builder.AllowAnyOrigin();
                          builder.AllowAnyMethod();//get post put delete patch 
                          builder.AllowAnyHeader();//
                      });
});




// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//JWT IMPLEMENTACI�N
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


/*CONFIGURANDO SWAGGER - PARA LA DOCUMENTACI�N DE NUESTROS WEB SERVICES*/
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BackEnd Consultoria",
        Version = "v1",
        Description = "Documentación de los servicios para el sistema de Consultoria de Proyectos",
        Contact = new OpenApiContact
        {
            Name = "Angelo Hinostroza / Enriqueta Achahue",
            Email = "hmoralesangelof@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/angelo-fabian-hinostroza-morales-b60653230/"),
        },
    }
    );
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});


//ESTA LINEA NOS SIRVE PARA CONFIGURAR NUESTRO AUTOMAPPER
builder.Services.AddAutoMapper(typeof(IStartup).Assembly, typeof(AutoMapperProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware(typeof(ErrorMiddleware));


app.MapControllers();
app.UseCors("origins");
app.Run();
