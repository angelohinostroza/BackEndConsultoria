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
    public class ProyectoBussnies : IProyectoBussnies
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IMapper _mapper;

        public ProyectoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _proyectoRepository = new ProyectoRepository();
        }

        public List<ProyectoResponse> GetAll()
        {
            List<ProyectoResponse> result = _mapper.Map<List<ProyectoResponse>>(_proyectoRepository.GetAll());
            return result;
        }

        public ProyectoResponse GetById(int id)
        {
            Proyecto proyecto = _proyectoRepository.GetById(id);
            ProyectoResponse result = _mapper.Map<ProyectoResponse>(proyecto);
            return result;
        }

        public ProyectoResponse Create(ProyectoRequest request)
        {
            Proyecto proyecto = _mapper.Map<Proyecto>(request);
            ProyectoResponse respuesta = _mapper.Map<ProyectoResponse>(_proyectoRepository.Create(proyecto));
            return respuesta;
        }

        public ProyectoResponse Update(ProyectoRequest request)
        {
            Proyecto proyecto = _mapper.Map<Proyecto>(request);
            ProyectoResponse respuesta = _mapper.Map<ProyectoResponse>(_proyectoRepository.Update(proyecto));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _proyectoRepository.Delete(id);
            return true;
        }

        public List<ProyectoResponse> CreateMultiple(List<ProyectoRequest> request)
        {
            List<Proyecto> proyecto = _mapper.Map<List<Proyecto>>(request);
            List<ProyectoResponse> respuesta = _mapper.Map<List<ProyectoResponse>>(_proyectoRepository.CreateMultiple(proyecto));
            return respuesta;
        }
        public List<ProyectoResponse> UpdateMultiple(List<ProyectoRequest> request)
        {
            List<Proyecto> proyecto = _mapper.Map<List<Proyecto>>(request);
            List<ProyectoResponse> respuesta = _mapper.Map<List<ProyectoResponse>>(_proyectoRepository.UpdateMultiple(proyecto));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public GenericFilterResponse<ProyectoResponse> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }

}
