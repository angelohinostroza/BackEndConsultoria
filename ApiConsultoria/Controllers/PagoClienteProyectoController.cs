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
    /// API REST PARA LA TABLA DE LOS PAGOS DE CLIENTES EN PROYECTOS
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PagoClienteProyectoController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        private readonly IPagoClienteProyectoBussnies _pagoClienteProyectoBussnies;
        private readonly IMapper _mapper;

        public PagoClienteProyectoController(IMapper mapper)
        {
            _mapper = mapper;
            _pagoClienteProyectoBussnies = new PagoClienteProyectoBussnies(mapper);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        #region CONTROLLERS CRUD BÁSICO

        /// <summary>
        /// RETORNA TODOS LOS PAGOS DE NUESTRA TABLA PAGOS CLIENTES EN PROYECTOS
        /// </summary>
        /// <returns>List-PagoClienteProyectoResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<PagoClienteProyectoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult ListarTodo()
        {
            List<PagoClienteProyectoResponse> lista = _pagoClienteProyectoBussnies.GetAll();
            return Ok(lista);
        }

        /// <summary>
        /// RETORNA EL REGISTRO POR PRIMERY KEY
        /// </summary>
        /// <returns>PagoClienteProyectoResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagoClienteProyectoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetById(short id)
        {
            PagoClienteProyectoResponse resultado = _pagoClienteProyectoBussnies.GetById(id);
            return Ok(resultado);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA PAGO CLIENTE PROYECTO
        /// </summary>
        /// <param name="request">PagoClienteProyectoRequest</param>
        /// <returns>PagoClienteProyectoResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagoClienteProyectoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult Crear([FromBody] PagoClienteProyectoRequest request)
        {
            PagoClienteProyectoResponse result = _pagoClienteProyectoBussnies.Create(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA PAGO CLIENTE PROYECTO
        /// </summary>
        /// <param name="request">PagoClienteProyectoRequest</param>
        /// <returns>PagoClienteProyectoResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagoClienteProyectoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Actualizar([FromBody] PagoClienteProyectoRequest request)
        {
            PagoClienteProyectoResponse result = _pagoClienteProyectoBussnies.Update(request);
            return StatusCode(200, result);
        }

        /// <summary>
        /// ELIMINA UN REGISTRO DE LA TABLA PAGO CLIENTE PROYECTO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>Bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult EliminarPorId(int id)
        {
            _pagoClienteProyectoBussnies.Delete(id);
            return StatusCode(200, true);
        }

        #endregion CONTROLLERS CRUD BÁSICO

        #region (CREATE / UPDATE) MULTIPLE

        /// <summary>
        /// INSERTA MULTIPLES REGISTROS EN LA TABLA PAGO CLIENTE PROYECTO
        /// </summary>
        /// <param name="request">List-PagoClienteProyectoRequest</param>
        /// <returns>List-PagoClienteProyectoResponse</returns>
        [HttpPost("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<PagoClienteProyectoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult CrearMultiple([FromBody] List<PagoClienteProyectoRequest> request)
        {
            List<PagoClienteProyectoResponse> result = _pagoClienteProyectoBussnies.CreateMultiple(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA MULTIPLES REGISTROS EN LA TABLA PAGO CLIENTE PROYECTO
        /// </summary>
        /// <param name="request">List-PagoClienteProyectoRequest</param>
        /// <returns>List-PagoClienteProyectoResponse</returns>
        [HttpPut("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<PagoClienteProyectoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ActualizarMultiple([FromBody] List<PagoClienteProyectoRequest> request)
        {
            List<PagoClienteProyectoResponse> result = _pagoClienteProyectoBussnies.UpdateMultiple(request);
            return StatusCode(200, result);
        }

        #endregion (CREATE / UPDATE) MULTIPLE
    }
}
