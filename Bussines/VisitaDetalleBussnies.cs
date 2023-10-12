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
    public class VisitaDetalleBussnies : IVisitaDetalleBussnies
    {
        private readonly IVisitaDetalleRepository _visitaDetalleRepository;
        private readonly IMapper _mapper;

        public VisitaDetalleBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _visitaDetalleRepository = new VisitaDetalleRepository();
        }

        public List<VisitaDetalleResponse> GetAll()
        {
            List<VisitaDetalleResponse> result = _mapper.Map<List<VisitaDetalleResponse>>(_visitaDetalleRepository.GetAll());
            return result;
        }

        public VisitaDetalleResponse GetById(int id)
        {
            VisitaDetalle visitaDetalle = _visitaDetalleRepository.GetById(id);
            VisitaDetalleResponse result = _mapper.Map<VisitaDetalleResponse>(visitaDetalle);
            return result;
        }

        public VisitaDetalleResponse Create(VisitaDetalleRequest request)
        {
            VisitaDetalle visitaDetalle = _mapper.Map<VisitaDetalle>(request);
            VisitaDetalleResponse respuesta = _mapper.Map<VisitaDetalleResponse>(_visitaDetalleRepository.Create(visitaDetalle));
            return respuesta;
        }

        public VisitaDetalleResponse Update(VisitaDetalleRequest request)
        {
            VisitaDetalle visitaDetalle = _mapper.Map<VisitaDetalle>(request);
            VisitaDetalleResponse respuesta = _mapper.Map<VisitaDetalleResponse>(_visitaDetalleRepository.Update(visitaDetalle));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _visitaDetalleRepository.Delete(id);
            return true;
        }

        public List<VisitaDetalleResponse> CreateMultiple(List<VisitaDetalleRequest> request)
        {
            List<VisitaDetalle> visitaDetalle = _mapper.Map<List<VisitaDetalle>>(request);
            List<VisitaDetalleResponse> respuesta = _mapper.Map<List<VisitaDetalleResponse>>(_visitaDetalleRepository.CreateMultiple(visitaDetalle));
            return respuesta;
        }
        public List<VisitaDetalleResponse> UpdateMultiple(List<VisitaDetalleRequest> request)
        {
            List<VisitaDetalle> visitaDetalle = _mapper.Map<List<VisitaDetalle>>(request);
            List<VisitaDetalleResponse> respuesta = _mapper.Map<List<VisitaDetalleResponse>>(_visitaDetalleRepository.UpdateMultiple(visitaDetalle));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public GenericFilterResponse<VisitaDetalleResponse> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }

}
