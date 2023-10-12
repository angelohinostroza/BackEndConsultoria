using ApiWeb.Middleware;
using AutoMapper;
using Bussnies;
using CommonModels;
using DbConsultoriaModel.dbConsultoria;
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
    public class ClienteController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        private readonly IClienteBussnies _clienteBussnies;
        private readonly IMapper _mapper;
        private readonly IHelperHttpContext _helperHttpContext = null;

        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
            _clienteBussnies = new ClienteBussnies(mapper);
            _helperHttpContext = new HelperHttpContext();
        }



        #endregion DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR

        #region CONTROLLERS CRUD BÁSICO


        /// <summary>
        /// RETORNA TODOS LOS CLIENTES DE NUESTRA TABLA CLIENTE
        /// </summary>
        /// <returns>List-ClienteResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<VclienteUbigeo>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ListarTodo(int pageSize = 3) // 3 es el valor predeterminado
        {
            List<VclienteUbigeo> lis = new List<VclienteUbigeo>();
            lis = _clienteBussnies.ObtenerCliente().Take(pageSize).ToList(); // Limita la cantidad de resultados a pageSize
            return Ok(lis);
        }

        /// <summary>
        /// RETORNA EL REGISTRO POR PRIMERY KEY
        /// </summary>
        /// <returns>ClienteResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClienteResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetById(int id)
        {
            ClienteResponse resultado = _clienteBussnies.GetById(id);
            return Ok(resultado);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA CLIENTE
        /// </summary>
        /// <param name="request">ClienteRequest</param>
        /// <returns>ClienteResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClienteResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Crear([FromBody] ClienteRequest request)
        {
            InfoRequest info = _helperHttpContext.GetInfoRequest(HttpContext);

            request.IdEmpleadoCrea = info.Claims.UserId;
            request.IdEmpleadoModifica = info.Claims.UserId;
            request.FechaCreacion = DateTime.Now;

            ClienteResponse result = _clienteBussnies.Create(request);

            return StatusCode(201, result);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA CLIENTE
        /// </summary>
        /// <param name="request">ClienteRequest</param>
        /// <returns>ClienteResponse</returns>
        [HttpPost("filter")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClienteResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Crear([FromBody] GenericFilterRequest request)

        {
            InfoRequest info = _helperHttpContext.GetInfoRequest(HttpContext);

            GenericFilterResponse<ClienteResponse> clients = _clienteBussnies.GetByFilter(request);

            return Ok(clients);

        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA CLIENTE
        /// </summary>
        /// <param name="request">ClienteRequest</param>
        /// <returns>ClienteResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClienteResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Actualizar([FromBody] ClienteRequest request)
        {

            InfoRequest info = _helperHttpContext.GetInfoRequest(HttpContext);

            request.IdEmpleadoModifica = info.Claims.UserId;
            request.FechaModificado = DateTime.Now;

            ClienteResponse result = _clienteBussnies.Update(request);

            return StatusCode(200, result);
        }

        /// <summary>
        /// ELIMINA UN REGISTRO DE LA TABLA CLIENTE POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>Bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult EliminarPorId(int id)
        {
            _clienteBussnies.Delete(id);
            return StatusCode(200, true);
        }

        #endregion CONTROLLERS CRUD BÁSICO

        #region (CREATE / UPDATE) MULTIPLE

        /// <summary>
        /// INSERTA MULTIPLES REGISTROS EN LA TABLA CLIENTE
        /// </summary>
        /// <param name="request">List-ClienteRequest</param>
        /// <returns>List-ClienteResponse</returns>
        [HttpPost("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ClienteResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult CrearMultiple([FromBody] List<ClienteRequest> request)
        {
            List<ClienteResponse> result = _clienteBussnies.CreateMultiple(request);
            return StatusCode(201, result);
        }

        /// <summary>
        /// ACTUALIZA MULTIPLES REGISTROS EN LA TABLA CLIENTE
        /// </summary>
        /// <param name="request">List-ClienteRequest</param>
        /// <returns>List-ClienteResponse</returns>
        [HttpPut("multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ClienteResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult ActualizarMultiple([FromBody] List<ClienteRequest> request)
        {
            List<ClienteResponse> result = _clienteBussnies.UpdateMultiple(request);
            return StatusCode(200, result);
        }

        #endregion (CREATE / UPDATE) MULTIPLE   

    }
}
