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
    public class DetalleCotizacionBussnies : IDetalleCotizacionBussnies
    {
        private readonly IDetalleCotizacionRepository _detalleCotizacionRepository;
        private readonly IMapper _mapper;

        public DetalleCotizacionBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _detalleCotizacionRepository = new DetalleCotizacionRepository();
        }

        public List<DetalleCotizacionResponse> GetAll()
        {
            List<DetalleCotizacionResponse> result = _mapper.Map<List<DetalleCotizacionResponse>>(_detalleCotizacionRepository.GetAll());
            return result;
        }

        public DetalleCotizacionResponse GetById(int id)
        {
            DetalleCotizacion detalleCotizacion = _detalleCotizacionRepository.GetById(id);
            DetalleCotizacionResponse result = _mapper.Map<DetalleCotizacionResponse>(detalleCotizacion);
            return result;
        }

        public DetalleCotizacionResponse Create(DetalleCotizacionRequest request)
        {
            DetalleCotizacion detalleCotizacion = _mapper.Map<DetalleCotizacion>(request);
            DetalleCotizacionResponse respuesta = _mapper.Map<DetalleCotizacionResponse>(_detalleCotizacionRepository.Create(detalleCotizacion));
            return respuesta;
        }

        public DetalleCotizacionResponse Update(DetalleCotizacionRequest request)
        {
            DetalleCotizacion detalleCotizacion = _mapper.Map<DetalleCotizacion>(request);
            DetalleCotizacionResponse respuesta = _mapper.Map<DetalleCotizacionResponse>(_detalleCotizacionRepository.Update(detalleCotizacion));
            return respuesta;
        }
        public bool Delete(object id)
        {
            _detalleCotizacionRepository.Delete(id);
            return true;
        }

        public List<DetalleCotizacionResponse> CreateMultiple(List<DetalleCotizacionRequest> request)
        {
            List<DetalleCotizacion> detalleCotizacion = _mapper.Map<List<DetalleCotizacion>>(request);
            List<DetalleCotizacionResponse> respuesta = _mapper.Map<List<DetalleCotizacionResponse>>(_detalleCotizacionRepository.CreateMultiple(detalleCotizacion));
            return respuesta;
        }
        public List<DetalleCotizacionResponse> UpdateMultiple(List<DetalleCotizacionRequest> request)
        {
            List<DetalleCotizacion> detalleCotizacion = _mapper.Map<List<DetalleCotizacion>>(request);
            List<DetalleCotizacionResponse> respuesta = _mapper.Map<List<DetalleCotizacionResponse>>(_detalleCotizacionRepository.UpdateMultiple(detalleCotizacion));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

    }

}
