using AutoMapper;
using Bussnies;
using IBussnies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponse;
using System.Net;

namespace ApiConsultoria.Controllers
{
    /// <summary>
    /// API REST PARA LA TABLA DE UBIGEO
    /// </summary>
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

    }
}

