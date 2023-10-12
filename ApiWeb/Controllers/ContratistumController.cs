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
    public class ContratistumController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        private readonly IContratistumBussnies _contratistumBussnies;
        private readonly IMapper _mapper;

        public ContratistumController(IMapper mapper)
        {
            _mapper = mapper;
            _contratistumBussnies = new ContratistumBussnies(mapper);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        #region CONTROLLERS CRUD BÁSICO

        /// <summary>
        /// RETORNA TODOS LOS CONTRATISTAS DE NUESTRA TABLA CONTRATISTA
        /// </summary>
        /// <returns>List-ContratistumResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ContratistumResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ListarTodo()
        {
            List<ContratistumResponse> lista = _contratistumBussnies.GetAll();
            return Ok(lista);
        }

        /// <summary>
        /// RETORNA EL REGISTRO POR PRIMERY KEY
        /// </summary>
        /// <returns>ContratistumResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContratistumResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetById(short id)
        {
            ContratistumResponse resultado = _contratistumBussnies.GetById(id);
            return Ok(resultado);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA CONTRATISTA
        /// </summary>
        /// <param name="request">ContratistumRequest</param>
        /// <returns>ContratistumResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContratistumResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]

        public IActionResult Crear([FromBody] ContratistumRequest request)
        {
            ContratistumResponse result = _contratistumBussnies.Create(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA CONTRATISTA
        /// </summary>
        /// <param name="request">ContratistumRequest</param>
        /// <returns>ContratistumResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContratistumResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Actualizar([FromBody] ContratistumRequest request)
        {
            ContratistumResponse result = _contratistumBussnies.Update(request);
            return StatusCode(200, result);
        }

        /// <summary>
        /// ELIMINA UN REGISTRO DE LA TABLA CONTRATISTA POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>Bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult EliminarPorId(int id)
        {
            _contratistumBussnies.Delete(id);
            return StatusCode(200, true);
        }

        #endregion CONTROLLERS CRUD BÁSICO

        #region (CREATE / UPDATE) MULTIPLE

        /// <summary>
        /// INSERTA MULTIPLES REGISTROS EN LA TABLA CONTRATISTA
        /// </summary>
        /// <param name="request">List-ContratistumRequest</param>
        /// <returns>List-ContratistumResponse</returns>
        [HttpPost("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ContratistumResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult CrearMultiple([FromBody] List<ContratistumRequest> request)
        {
            List<ContratistumResponse> result = _contratistumBussnies.CreateMultiple(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA MULTIPLES REGISTROS EN LA TABLA CONTRATISTA
        /// </summary>
        /// <param name="request">List-ContratistumRequest</param>
        /// <returns>List-ContratistumResponse</returns>
        [HttpPut("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ContratistumResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ActualizarMultiple([FromBody] List<ContratistumRequest> request)
        {
            List<ContratistumResponse> result = _contratistumBussnies.UpdateMultiple(request);
            return StatusCode(200, result);
        }

        #endregion (CREATE / UPDATE) MULTIPLE
    }
}
