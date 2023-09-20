using AutoMapper;
using DbConsultoriaModel.dbConsultoria;
using IBussnies;
using IRepository;
using Repository;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class CotizacionBussnies : ICotizacionBussnies
    {
        private readonly ICotizacionRepository _cotizacionRepository;
        private readonly IMapper _mapper;

        public CotizacionBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _cotizacionRepository = new CotizacionRepository();
        }

        public List<CotizacionResponse> GetAll()
        {
            List<CotizacionResponse> result = _mapper.Map<List<CotizacionResponse>>(_cotizacionRepository.GetAll());
            return result;
        }

        public CotizacionResponse GetById(int id)
        {
            Cotizacion cotizacion = _cotizacionRepository.GetById(id);
            CotizacionResponse result = _mapper.Map<CotizacionResponse>(cotizacion);
            return result;
        }

        public CotizacionResponse Create(CotizacionRequest request)
        {
            Cotizacion cotizacion = _mapper.Map<Cotizacion>(request);
            CotizacionResponse respuesta = _mapper.Map<CotizacionResponse>(_cotizacionRepository.Create(cotizacion));
            return respuesta;
        }

        public CotizacionResponse Update(CotizacionRequest request)
        {
            Cotizacion cotizacion = _mapper.Map<Cotizacion>(request);
            CotizacionResponse respuesta = _mapper.Map<CotizacionResponse>(_cotizacionRepository.Update(cotizacion));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _cotizacionRepository.Delete(id);
            return true;
        }

        public List<CotizacionResponse> CreateMultiple(List<CotizacionRequest> request)
        {
            List<Cotizacion> cotizacion = _mapper.Map<List<Cotizacion>>(request);
            List<CotizacionResponse> respuesta = _mapper.Map<List<CotizacionResponse>>(_cotizacionRepository.CreateMultiple(cotizacion));
            return respuesta;
        }
        public List<CotizacionResponse> UpdateMultiple(List<CotizacionRequest> request)
        {
            List<Cotizacion> cotizacion = _mapper.Map<List<Cotizacion>>(request);
            List<CotizacionResponse> respuesta = _mapper.Map<List<CotizacionResponse>>(_cotizacionRepository.UpdateMultiple(cotizacion));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

    }
   
}
