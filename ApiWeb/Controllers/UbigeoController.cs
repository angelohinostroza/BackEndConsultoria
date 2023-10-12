using AutoMapper;
using Bussnies;
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
    [AllowAnonymous]
    public class UbigeoController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR 

        private readonly IMapper _mapper;
        private readonly IUbigeoBussnies _ubigeoBussnies;

        public UbigeoController(IMapper mapper)
        {
            _mapper = mapper;
            _ubigeoBussnies = new UbigeoBussnies(mapper);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CREACION DEL CONSTRUCTOR

        /// <summary>
        /// RETORNA LA LISTA DE UBIGEOS QUE COINCIDAN CON EL TEXTO INGRESADO
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        [HttpGet("autocomplete")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UbigeoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult getByContains(string texto)
        {
            List<UbigeoResponse> list = _ubigeoBussnies.getByContains(texto);
            return Ok(list);
        }


        /// <summary>
        /// RETORNA TODOS LOS CLIENTES DE NUESTRA TABLA CLIENTE
        /// </summary>
        /// <returns>List-ClienteResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UbigeoResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetAll()
        {
            List<UbigeoResponse> lst = _ubigeoBussnies.GetAll();
            return Ok(lst);
        }




        /// <summary>
        /// RETORNA EL REGISTRO POR PRIMERY KEY
        /// </summary>
        /// <returns>ClienteResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UbigeoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetById(int id)
        {
            UbigeoResponse lst = _ubigeoBussnies.GetById(id);
            return Ok(lst);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA CLIENTE
        /// </summary>
        /// <param name="request">ClienteRequest</param>
        /// <returns>ClienteResponse</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UbigeoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] UbigeoRequest request)
        {
            UbigeoResponse cat = _ubigeoBussnies.Create(request);

            return Ok(cat);
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA CLIENTE
        /// </summary>
        /// <param name="filter">ClienteRequest</param>
        /// <returns>ClienteResponse</returns>
        [HttpPost("filter")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UbigeoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetByFilter([FromBody] GenericFilterRequest filter)
        {
            GenericFilterResponse<UbigeoResponse> res = _ubigeoBussnies.GetByFilter(filter);
            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA CLIENTE
        /// </summary>
        /// <param name="request">ClienteRequest</param>
        /// <returns>ClienteResponse</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UbigeoResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] UbigeoRequest request)
        {
            UbigeoResponse cat = _ubigeoBussnies.Update(request);

            return Ok(cat);
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
            _ubigeoBussnies.Delete(id);
            return StatusCode(200, true);
        }

    }
}

