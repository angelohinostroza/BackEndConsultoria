using AutoMapper;
using Bussnies;
using IBussnies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponse;
using System.Net;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        private readonly IUsuarioBussnies _usuarioBussnies;
        private readonly IMapper _mapper;

        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioBussnies = new UsuarioBussnies(mapper);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        #region CONTROLLERS CRUD BÁSICO

        /// <summary>
        /// RETORNA TODOS LOS USUARIOS DE NUESTRA TABLA USUARIOS
        /// </summary>
        /// <returns>List-UsuarioResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult ListarTodo()
        {
            List<UsuarioResponse> lista = _usuarioBussnies.GetAll();
            return Ok(lista);
        }

        /// <summary>
        /// RETORNA EL REGISTRO POR PRIMERY KEY
        /// </summary>
        /// <returns>UsuarioResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetById(short id)
        {
            UsuarioResponse resultado = _usuarioBussnies.GetById(id);
            return Ok(resultado);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA USUARIO
        /// </summary>
        /// <param name="request">UsuarioRequest</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult Crear([FromBody] UsuarioRequest request)
        {
            UsuarioResponse result = _usuarioBussnies.Create(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA USUARIO
        /// </summary>
        /// <param name="request">UsuarioRequest</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UsuarioResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Actualizar([FromBody] UsuarioRequest request)
        {
            UsuarioResponse result = _usuarioBussnies.Update(request);
            return StatusCode(200, result);
        }

        /// <summary>
        /// ELIMINA UN REGISTRO DE LA TABLA USUARIO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>Bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult EliminarPorId(int id)
        {
            _usuarioBussnies.Delete(id);
            return StatusCode(200, true);
        }

        #endregion CONTROLLERS CRUD BÁSICO

        #region (CREATE / UPDATE) MULTIPLE

        /// <summary>
        /// INSERTA MULTIPLES REGISTROS EN LA TABLA USUARIO
        /// </summary>
        /// <param name="request">List-UsuarioRequest</param>
        /// <returns>List-UsuarioResponse</returns>
        [HttpPost("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult CrearMultiple([FromBody] List<UsuarioRequest> request)
        {
            List<UsuarioResponse> result = _usuarioBussnies.CreateMultiple(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA MULTIPLES REGISTROS EN LA TABLA USUARIO
        /// </summary>
        /// <param name="request">List-UsuarioRequest</param>
        /// <returns>List-UsuarioResponse</returns>
        [HttpPut("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UsuarioResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ActualizarMultiple([FromBody] List<UsuarioRequest> request)
        {
            List<UsuarioResponse> result = _usuarioBussnies.UpdateMultiple(request);
            return StatusCode(200, result);
        }

        #endregion (CREATE / UPDATE) MULTIPLE
    }
}
