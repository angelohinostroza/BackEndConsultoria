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
    public class PagoClienteProyectoBussnies : IPagoClienteProyectoBussnies
    {
        private readonly IPagoClienteProyectoRepository _pagoClienteProyectoRepository;
        private readonly IMapper _mapper;

        public PagoClienteProyectoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _pagoClienteProyectoRepository = new PagoClienteProyectoRepository();
        }

        public List<PagoClienteProyectoResponse> GetAll()
        {
            List<PagoClienteProyectoResponse> result = _mapper.Map<List<PagoClienteProyectoResponse>>(_pagoClienteProyectoRepository.GetAll());
            return result;
        }

        public PagoClienteProyectoResponse Create(PagoClienteProyectoRequest request)
        {
            PagoClienteProyecto pagoClienteProyecto = _mapper.Map<PagoClienteProyecto>(request);
            PagoClienteProyectoResponse respuesta = _mapper.Map<PagoClienteProyectoResponse>(_pagoClienteProyectoRepository.Create(pagoClienteProyecto));
            return respuesta;
        }

        public PagoClienteProyectoResponse Update(PagoClienteProyectoRequest request)
        {
            PagoClienteProyecto pagoClienteProyecto = _mapper.Map<PagoClienteProyecto>(request);
            PagoClienteProyectoResponse respuesta = _mapper.Map<PagoClienteProyectoResponse>(_pagoClienteProyectoRepository.Update(pagoClienteProyecto));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _pagoClienteProyectoRepository.Delete(id);
            return true;
        }

        public List<PagoClienteProyectoResponse> CreateMultiple(List<PagoClienteProyectoRequest> request)
        {
            List<PagoClienteProyecto> pagoClienteProyecto = _mapper.Map<List<PagoClienteProyecto>>(request);
            List<PagoClienteProyectoResponse> respuesta = _mapper.Map<List<PagoClienteProyectoResponse>>(_pagoClienteProyectoRepository.CreateMultiple(pagoClienteProyecto));
            return respuesta;
        }
        public List<PagoClienteProyectoResponse> UpdateMultiple(List<PagoClienteProyectoRequest> request)
        {
            List<PagoClienteProyecto> pagoClienteProyecto = _mapper.Map<List<PagoClienteProyecto>>(request);
            List<PagoClienteProyectoResponse> respuesta = _mapper.Map<List<PagoClienteProyectoResponse>>(_pagoClienteProyectoRepository.UpdateMultiple(pagoClienteProyecto));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        public PagoClienteProyectoResponse GetById(int id)
        {
            PagoClienteProyecto pagoClienteProyecto = _pagoClienteProyectoRepository.GetById(id);
            PagoClienteProyectoResponse result = _mapper.Map<PagoClienteProyectoResponse>(pagoClienteProyecto);
            return result;
        }
    }

}
