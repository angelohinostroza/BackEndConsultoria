using AutoMapper;
using Bussnies;
using IBussnies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponse;
using System.Net;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultorController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR

        private readonly IConsultorBussnies _consultorBussnies;
        private readonly IMapper _mapper;

        public ConsultorController(IMapper mapper)
        {
            _mapper = mapper;
            _consultorBussnies = new ConsultorBussnies(mapper);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR


        #region CONTROLLERS CRUD BÁSICO

        /// <summary>
        /// RETORNA TODOS LOS CONSULTORES DE NUESTRA TABLA CONSULTOR
        /// </summary>
        /// <returns>List-ConsultorResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ConsultorResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult ListarTodo()
        {
            List<ConsultorResponse> lista = _consultorBussnies.GetAll();
            return Ok(lista);
        }

        /// <summary>
        /// RETORNA EL REGISTRO POR PRIMERY KEY
        /// </summary>
        /// <returns>ConsultorResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultorResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetById(short id)
        {
            ConsultorResponse resultado = _consultorBussnies.GetById(id);
            return Ok(resultado);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA CONSULTOR
        /// </summary>
        /// <param name="request">ConsultorRequest</param>
        /// <returns>ConsultorResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultorResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult Crear([FromBody] ConsultorRequest request)
        {
            ConsultorResponse result = _consultorBussnies.Create(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA CONSULTOR
        /// </summary>
        /// <param name="request">ConsultorRequest</param>
        /// <returns>ConsultorResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultorResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Actualizar([FromBody] ConsultorRequest request)
        {
            ConsultorResponse result = _consultorBussnies.Update(request);
            return StatusCode(200, result);
        }

        /// <summary>
        /// ELIMINA UN REGISTRO DE LA TABLA CONSULTOR POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>Bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult EliminarPorId(int id)
        {
            _consultorBussnies.Delete(id);
            return StatusCode(200, true);
        }

        #endregion CONTROLLERS CRUD BÁSICO

        #region (CREATE / UPDATE) MULTIPLE

        /// <summary>
        /// INSERTA MULTIPLES REGISTROS EN LA TABLA CONSULTOR
        /// </summary>
        /// <param name="request">List-ConsultorRequest</param>
        /// <returns>List-ConsultorResponse</returns>
        [HttpPost("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ConsultorResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult CrearMultiple([FromBody] List<ConsultorRequest> request)
        {
            List<ConsultorResponse> result = _consultorBussnies.CreateMultiple(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA MULTIPLES REGISTROS EN LA TABLA CONSULTOR
        /// </summary>
        /// <param name="request">List-ConsultorRequest</param>
        /// <returns>List-ConsultorResponse</returns>
        [HttpPut("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ConsultorResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ActualizarMultiple([FromBody] List<ConsultorRequest> request)
        {
            List<ConsultorResponse> result = _consultorBussnies.UpdateMultiple(request);
            return StatusCode(200, result);
        }

        #endregion (CREATE / UPDATE) MULTIPLE
    }
}
