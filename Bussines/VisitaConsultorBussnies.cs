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
    public class VisitaConsultorBussnies : IVisitaConsultorBussnies
    {
        private readonly IVisitaConsultorRepository _visitaConsultorRepository;
        private readonly IMapper _mapper;

        public VisitaConsultorBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _visitaConsultorRepository = new VisitaConsultorRepository();
        }

        public List<VisitaConsultorResponse> GetAll()
        {
            List<VisitaConsultorResponse> result = _mapper.Map<List<VisitaConsultorResponse>>(_visitaConsultorRepository.GetAll());
            return result;
        }

        public VisitaConsultorResponse GetById(int id)
        {
            VisitaConsultor visitaConsultor = _visitaConsultorRepository.GetById(id);
            VisitaConsultorResponse result = _mapper.Map<VisitaConsultorResponse>(visitaConsultor);
            return result;
        }

        public VisitaConsultorResponse Create(VisitaConsultorRequest request)
        {
            VisitaConsultor visitaConsultor = _mapper.Map<VisitaConsultor>(request);
            VisitaConsultorResponse respuesta = _mapper.Map<VisitaConsultorResponse>(_visitaConsultorRepository.Create(visitaConsultor));
            return respuesta;
        }

        public VisitaConsultorResponse Update(VisitaConsultorRequest request)
        {
            VisitaConsultor visitaConsultor = _mapper.Map<VisitaConsultor>(request);
            VisitaConsultorResponse respuesta = _mapper.Map<VisitaConsultorResponse>(_visitaConsultorRepository.Update(visitaConsultor));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _visitaConsultorRepository.Delete(id);
            return true;
        }

        public List<VisitaConsultorResponse> CreateMultiple(List<VisitaConsultorRequest> request)
        {
            List<VisitaConsultor> visitaConsultor = _mapper.Map<List<VisitaConsultor>>(request);
            List<VisitaConsultorResponse> respuesta = _mapper.Map<List<VisitaConsultorResponse>>(_visitaConsultorRepository.CreateMultiple(visitaConsultor));
            return respuesta;
        }
        public List<VisitaConsultorResponse> UpdateMultiple(List<VisitaConsultorRequest> request)
        {
            List<VisitaConsultor> visitaConsultor = _mapper.Map<List<VisitaConsultor>>(request);
            List<VisitaConsultorResponse> respuesta = _mapper.Map<List<VisitaConsultorResponse>>(_visitaConsultorRepository.UpdateMultiple(visitaConsultor));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public GenericFilterResponse<VisitaConsultorResponse> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }

}
