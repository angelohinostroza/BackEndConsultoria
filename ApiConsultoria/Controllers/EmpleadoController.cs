using AutoMapper;
using Bussnies;
using IBussnies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponse;
using System.Net;

namespace ApiConsultoria.Controllers
{
    /// <summary>
    /// API REST PARA LA TABLA DE EMPLEADOS
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        private readonly IEmpeladoBussnies _empleadoBussnies;
        private readonly IMapper _mapper;

        /*2 inicializar variables en el constructor*/
        public EmpleadoController(IMapper mapper)
        {
            _mapper = mapper;
            _empleadoBussnies = new EmpleadoBussnies(mapper);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        #region CONTROLLERS CRUD BÁSICO

        /// <summary>
        /// RETORNA TODOS LOS EMPLEADOS DE NUESTRA TABLA EMPLEADO
        /// </summary>
        /// <returns>List-EmpleadoResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<EmpleadoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ListarTodo()
        {
            List<EmpleadoResponse> lista = _empleadoBussnies.GetAll();
            return Ok(lista);
        }

        /// <summary>
        /// RETORNA EL REGISTRO POR PRIMERY KEY
        /// </summary>
        /// <returns>EmpleadoResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(EmpleadoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetById(short id)
        {
            EmpleadoResponse resultado = _empleadoBussnies.GetById(id);
            return Ok(resultado);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA EMPLEADO
        /// </summary>
        /// <param name="request">EmpleadoRequest</param>
        /// <returns>EmpleadoResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(EmpleadoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Crear([FromBody] EmpleadoRequest request)
        {
            EmpleadoResponse result = _empleadoBussnies.Create(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA EMPLEADO
        /// </summary>
        /// <param name="request">EmpleadoRequest</param>
        /// <returns>EmpleadoResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(EmpleadoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Actualizar([FromBody] EmpleadoRequest request)
        {
            EmpleadoResponse result = _empleadoBussnies.Update(request);
            return StatusCode(200, result);
        }

        /// <summary>
        /// ELIMINA UN REGISTRO DE LA TABLA EMPLEADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>Bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult EliminarPorId(int id)
        {
            _empleadoBussnies.Delete(id);
            return StatusCode(200, true);
        }

        #endregion CONTROLLERS CRUD BÁSICO

        #region (CREATE / UPDATE) MULTIPLE

        /// <summary>
        /// INSERTA MULTIPLES REGISTROS EN LA TABLA EMPLEADO
        /// </summary>
        /// <param name="request">List-EmpleadoRequest</param>
        /// <returns>List-EmpleadoResponse</returns>
        [HttpPost("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<EmpleadoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult CrearMultiple([FromBody] List<EmpleadoRequest> request)
        {
            List<EmpleadoResponse> result = _empleadoBussnies.CreateMultiple(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA MULTIPLES REGISTROS EN LA TABLA EMPLEADO
        /// </summary>
        /// <param name="request">List-EmpleadoRequest</param>
        /// <returns>List-EmpleadoResponse</returns>
        [HttpPut("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<EmpleadoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ActualizarMultiple([FromBody] List<EmpleadoRequest> request)
        {
            List<EmpleadoResponse> result = _empleadoBussnies.UpdateMultiple(request);
            return StatusCode(200, result);
        }

        #endregion (CREATE / UPDATE) MULTIPLE
    }
}
