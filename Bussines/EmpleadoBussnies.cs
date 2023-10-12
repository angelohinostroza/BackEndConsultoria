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
    public class EmpleadoBussnies : IEmpeladoBussnies
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public EmpleadoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _empleadoRepository = new EmpleadoRepository();
        }

        public List<EmpleadoResponse> GetAll()
        {
            List<EmpleadoResponse> result = _mapper.Map<List<EmpleadoResponse>>(_empleadoRepository.GetAll());
            return result;
        }

        public EmpleadoResponse GetById(int id)
        {
            Empleado empleado = _empleadoRepository.GetById(id);
            EmpleadoResponse result = _mapper.Map<EmpleadoResponse>(empleado);
            return result;
        }

        public EmpleadoResponse Create(EmpleadoRequest request)
        {
            Empleado empleado = _mapper.Map<Empleado>(request);
            EmpleadoResponse respuesta = _mapper.Map<EmpleadoResponse>(_empleadoRepository.Create(empleado));
            return respuesta;
        }

        public EmpleadoResponse Update(EmpleadoRequest request)
        {
            Empleado empleado = _mapper.Map<Empleado>(request);
            EmpleadoResponse respuesta = _mapper.Map<EmpleadoResponse>(_empleadoRepository.Update(empleado));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _empleadoRepository.Delete(id);
            return true;
        }

        public List<EmpleadoResponse> CreateMultiple(List<EmpleadoRequest> request)
        {
            List<Empleado> empleado = _mapper.Map<List<Empleado>>(request);
            List<EmpleadoResponse> respuesta = _mapper.Map<List<EmpleadoResponse>>(_empleadoRepository.CreateMultiple(empleado));
            return respuesta;
        }
        public List<EmpleadoResponse> UpdateMultiple(List<EmpleadoRequest> request)
        {
            List<Empleado> empleado = _mapper.Map<List<Empleado>>(request);
            List<EmpleadoResponse> respuesta = _mapper.Map<List<EmpleadoResponse>>(_empleadoRepository.UpdateMultiple(empleado));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public GenericFilterResponse<EmpleadoResponse> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }
}
