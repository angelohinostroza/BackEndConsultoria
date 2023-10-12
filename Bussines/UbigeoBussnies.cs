using AutoMapper;
using Azure.Core;
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
    public class UbigeoBussnies : IUbigeoBussnies
    {
        private readonly IUbigeoRepository _ubigeoRepository;
        private readonly IMapper _mapper;

        public UbigeoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _ubigeoRepository = new UbigeoRepository();
        }
        public List<UbigeoResponse> GetAll()
        {
            List<UbigeoResponse> result = _mapper.Map<List<UbigeoResponse>>(_ubigeoRepository.GetAll());
            return result;
        }

        public UbigeoResponse GetById(int id)
        {
            Ubigeo ubigeo = _ubigeoRepository.GetById(id);
            UbigeoResponse result = _mapper.Map<UbigeoResponse>(ubigeo);
            return result;
        }

        public UbigeoResponse Create(UbigeoRequest request)
        {
            Ubigeo ubigeo = _mapper.Map<Ubigeo>(request);
            UbigeoResponse respuesta = _mapper.Map<UbigeoResponse>(_ubigeoRepository.Create(ubigeo));
            return respuesta;
        }
        public UbigeoResponse Update(UbigeoRequest request)
        {
            Ubigeo ubigeo = _mapper.Map<Ubigeo>(request);
            UbigeoResponse respuesta = _mapper.Map<UbigeoResponse>(_ubigeoRepository.Update(ubigeo));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _ubigeoRepository.Delete(id);
            return true;
        }
        public List<UbigeoResponse> CreateMultiple(List<UbigeoRequest> request)
        {
            List<Ubigeo> ubigeo = _mapper.Map<List<Ubigeo>>(request);
            List<UbigeoResponse> respuesta = _mapper.Map<List<UbigeoResponse>>(_ubigeoRepository.CreateMultiple(ubigeo));
            return respuesta;
        }

        public List<UbigeoResponse> UpdateMultiple(List<UbigeoRequest> request)
        {
            List<Ubigeo> ubigeo = _mapper.Map<List<Ubigeo>>(request);
            List<UbigeoResponse> respuesta = _mapper.Map<List<UbigeoResponse>>(_ubigeoRepository.UpdateMultiple(ubigeo));
            return respuesta;
        }

     
        public List<UbigeoResponse> getByContains(string texto)
        {
            List<UbigeoResponse> respuesta = _mapper.Map<List<UbigeoResponse>>(_ubigeoRepository.getByContains(texto));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public GenericFilterResponse<UbigeoResponse> GetByFilter(GenericFilterRequest filter)
        {
            GenericFilterResponse<Ubigeo> cats = _ubigeoRepository.GetByFilter(filter);
            GenericFilterResponse<UbigeoResponse> res = new GenericFilterResponse<UbigeoResponse>();
            res.TotalRecord = cats.TotalRecord;
            res.List = _mapper.Map<List<UbigeoResponse>>(cats.List);
            return res;
        }
    }
}
