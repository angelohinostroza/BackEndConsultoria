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
    public class ContratistumBussnies : IContratistumBussnies
    {
        private readonly IContratistumRepository _contratistumRepository;
        private readonly IMapper _mapper;

        public ContratistumBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _contratistumRepository = new ContratistumRepository();
        }

        public List<ContratistumResponse> GetAll()
        {
            List<ContratistumResponse> result = _mapper.Map<List<ContratistumResponse>>(_contratistumRepository.GetAll());
            return result;
        }

        public ContratistumResponse GetById(int id)
        {
            Contratistum contratistum = _contratistumRepository.GetById(id);
            ContratistumResponse result = _mapper.Map<ContratistumResponse>(contratistum);
            return result;
        }


        public ContratistumResponse Create(ContratistumRequest request)
        {
            Contratistum contratistum = _mapper.Map<Contratistum>(request);
            ContratistumResponse respuesta = _mapper.Map<ContratistumResponse>(_contratistumRepository.Create(contratistum));
            return respuesta;
        }

        public ContratistumResponse Update(ContratistumRequest request)
        {
            Contratistum contratistum = _mapper.Map<Contratistum>(request);
            ContratistumResponse respuesta = _mapper.Map<ContratistumResponse>(_contratistumRepository.Update(contratistum));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _contratistumRepository.Delete(id);
            return true;
        }

        public List<ContratistumResponse> CreateMultiple(List<ContratistumRequest> request)
        {
            List<Contratistum> contratistum = _mapper.Map<List<Contratistum>>(request);
            List<ContratistumResponse> respuesta = _mapper.Map<List<ContratistumResponse>>(_contratistumRepository.CreateMultiple(contratistum));
            return respuesta;
        }
        public List<ContratistumResponse> UpdateMultiple(List<ContratistumRequest> request)
        {
            List<Contratistum> contratistum = _mapper.Map<List<Contratistum>>(request);
            List<ContratistumResponse> respuesta = _mapper.Map<List<ContratistumResponse>>(_contratistumRepository.UpdateMultiple(contratistum));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public GenericFilterResponse<ContratistumResponse> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }
}
