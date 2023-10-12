using AutoMapper;
using Bussnies;
using IBussnies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RequestResponse;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ApiConsultoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

    /// <summary>
    /// REALIZA LOS PROCESOS RELACIONADOS A LA AUTENTICACIÓN
    /// </summary>
    public class AuthController : ControllerBase
    {
        #region DECLARACION DE VARIABLES / CONSTRUCTOR

        private readonly IMapper _mapper;
        private readonly IAuthBussnies _authBussnies;
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="mapper"></param>
        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
            _authBussnies = new AuthBussnies(mapper);
        }

        #endregion DECLARACION DE VARIABLES / CONSTRUCTOR

        #region METODOS PUBLICOS

        /// <summary>
        /// Si el servicio está activo, retorna un true
        /// </summary>
        /// <returns>TRUE</returns>
        [HttpGet]
        public IActionResult Listen()
        {
            return Ok(true);
        }

        /// <summary>
        /// REALIZA EL PROCESO DE LOGIN Y GENERA EL TOKEN DE AUTENTICACIÓN
        /// </summary>
        /// <param name="request">LoginRequest</param>
        /// <returns>LoginResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Login([FromBody] LoginRequest request)
        {
           
            LoginResponse response = _authBussnies.Login(request);

            if (!response.Success) 
            {
                return Ok(response);
            }

            response.Token = CreateToken(response);
            response.RefreshToken = new Guid().ToString();

            return Ok(response);
        }
        #endregion METODOS PUBLICOS

        #region INICIO METODOS PRIVADOS

        private string CreateToken(LoginResponse oLoginResponse)
        {
         
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();


            int tiempoVida = int.Parse(configurationFile["Jwt:TimeJWTMin"]);
        
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),// - UTC-0
                        new Claim(ClaimTypes.Role, oLoginResponse.Usuario.IdRol.ToString()),
                        new Claim("UserId", oLoginResponse.Usuario.IdUsuario.ToString()),
                        new Claim("DisplayName", oLoginResponse.NombresEmpleado),
                        new Claim("UserName", oLoginResponse.Usuario.NombreUsuario),
                        new Claim("RoleName", oLoginResponse.NombreRol),
                 
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configurationFile["Jwt:Issuer"],
                configurationFile["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(tiempoVida),
                signingCredentials: signIn);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion FIN METODOS PRIVADOS


    }
}
