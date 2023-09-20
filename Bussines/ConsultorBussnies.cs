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
    public class ConsultorBussnies : IConsultorBussnies
    {
        private readonly IConsultorRepository _consultorRepository;
        private readonly IMapper _mapper;

        public ConsultorBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _consultorRepository = new ConsultorRepository();
        }

        public List<ConsultorResponse> GetAll()
        {
            List<ConsultorResponse> result = _mapper.Map<List<ConsultorResponse>>(_consultorRepository.GetAll());
            return result;
        }

        public ConsultorResponse GetById(int id)
        {
            Consultor consultor = _consultorRepository.GetById(id);
            ConsultorResponse result = _mapper.Map<ConsultorResponse>(consultor);
            return result;
        }

        public ConsultorResponse Create(ConsultorRequest request)
        {
            Consultor consultor = _mapper.Map<Consultor>(request);
            ConsultorResponse respuesta = _mapper.Map<ConsultorResponse>(_consultorRepository.Create(consultor));
            return respuesta;
        }

        public ConsultorResponse Update(ConsultorRequest request)
        {
            Consultor consultor = _mapper.Map<Consultor>(request);
            ConsultorResponse respuesta = _mapper.Map<ConsultorResponse>(_consultorRepository.Update(consultor));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _consultorRepository.Delete(id);
            return true;
        }

        public List<ConsultorResponse> CreateMultiple(List<ConsultorRequest> request)
        {
            List<Consultor> consultor = _mapper.Map<List<Consultor>>(request);
            List<ConsultorResponse> respuesta = _mapper.Map<List<ConsultorResponse>>(_consultorRepository.CreateMultiple(consultor));
            return respuesta;
        }
        public List<ConsultorResponse> UpdateMultiple(List<ConsultorRequest> request)
        {
            List<Consultor> consultor = _mapper.Map<List<Consultor>>(request);
            List<ConsultorResponse> respuesta = _mapper.Map<List<ConsultorResponse>>(_consultorRepository.UpdateMultiple(consultor));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

    }
    
}

