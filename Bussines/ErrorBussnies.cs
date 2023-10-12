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
    public class ErrorBussnies : IErrorBussnies
    {
        private readonly IErrorRepository _ErrorRepository;
        private readonly IMapper _mapper;

        public ErrorBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _ErrorRepository = new ErrorRepository();

        }

        public List<ErrorResponse> GetAll()
        {
            List<ErrorResponse> result = _mapper.Map<List<ErrorResponse>>(_ErrorRepository.GetAll());
            return result;
        }
        public ErrorResponse GetById(int id)
        {
            Error Error = _ErrorRepository.GetById(id);
            ErrorResponse result = _mapper.Map<ErrorResponse>(Error);
            return result;
        }

        public ErrorResponse Create(ErrorRequest request)
        {
            Error Error = _mapper.Map<Error>(request);
            ErrorResponse respuesta = _mapper.Map<ErrorResponse>(_ErrorRepository.Create(Error));
            return respuesta;
        }

        public ErrorResponse Update(ErrorRequest request)
        {
            Error Error = _mapper.Map<Error>(request);
            ErrorResponse respuesta = _mapper.Map<ErrorResponse>(_ErrorRepository.Update(Error));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _ErrorRepository.Delete(id);
            return true;
        }

        public List<ErrorResponse> CreateMultiple(List<ErrorRequest> request)
        {
            List<Error> Error = _mapper.Map<List<Error>>(request);
            List<ErrorResponse> respuesta = _mapper.Map<List<ErrorResponse>>(_ErrorRepository.CreateMultiple(Error));
            return respuesta;
        }
        public List<ErrorResponse> UpdateMultiple(List<ErrorRequest> request)
        {
            List<Error> Error = _mapper.Map<List<Error>>(request);
            List<ErrorResponse> respuesta = _mapper.Map<List<ErrorResponse>>(_ErrorRepository.UpdateMultiple(Error));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public GenericFilterResponse<ErrorResponse> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }
}
