using AutoMapper;
using DbConsultoriaModel.dbConsultoria;
using IBussnies;
using IRepository;
using Repository;
using RequestResponse;
using System.Collections.Generic;

namespace Bussnies
{
    public class RolBussnies : IRolBussnies
    {   
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;

        public RolBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _rolRepository = new RolRepository();

        }

        public List<RolResponse> GetAll()
        {
            List<RolResponse> result = _mapper.Map<List<RolResponse>>(_rolRepository.GetAll());
            return result;
        }
        public RolResponse GetById(int id)
        {
            Rol rol = _rolRepository.GetById(id);
            RolResponse result = _mapper.Map<RolResponse>(rol);
            return result;
        }

        public RolResponse Create(RolRequest request)
        {
            Rol rol = _mapper.Map<Rol>(request);
            RolResponse respuesta = _mapper.Map<RolResponse>(_rolRepository.Create(rol));
            return respuesta;
        }

        public RolResponse Update(RolRequest request)
        {
            Rol rol = _mapper.Map<Rol>(request);
            RolResponse respuesta = _mapper.Map<RolResponse>(_rolRepository.Update(rol));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _rolRepository.Delete(id);
            return true;
        }

        public List<RolResponse> CreateMultiple(List<RolRequest> request)
        {
            List<Rol> rol = _mapper.Map<List<Rol>>(request);
            List<RolResponse> respuesta = _mapper.Map<List<RolResponse>>(_rolRepository.CreateMultiple(rol));
            return respuesta;
        }
        public List<RolResponse> UpdateMultiple(List<RolRequest> request)
        {
            List<Rol> rol = _mapper.Map<List<Rol>>(request);
            List<RolResponse> respuesta = _mapper.Map<List<RolResponse>>(_rolRepository.UpdateMultiple(rol));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public GenericFilterResponse<RolResponse> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }
}