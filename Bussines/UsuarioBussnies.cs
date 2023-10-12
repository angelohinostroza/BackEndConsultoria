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
    public class UsuarioBussnies : IUsuarioBussnies

    {
        #region declaracion de variables y constructor
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = new UsuarioRepository();
        }
        #endregion declaracion de variables y constructor

        #region CRUD METHODS

        public List<UsuarioResponse> GetAll()
        {
            List<UsuarioResponse> result = _mapper.Map<List<UsuarioResponse>>(_usuarioRepository.GetAll());
            return result;
        }

        public UsuarioResponse GetById(int id)
        {
            Usuario usuario = _usuarioRepository.GetById(id);
            UsuarioResponse result = _mapper.Map<UsuarioResponse>(usuario);
            return result;
        }

        public UsuarioResponse Create(UsuarioRequest request)
        {
            Usuario usuario = _mapper.Map<Usuario>(request);
            UsuarioResponse respuesta = _mapper.Map<UsuarioResponse>(_usuarioRepository.Create(usuario));
            return respuesta;
        }

        public UsuarioResponse Update(UsuarioRequest request)
        {
            Usuario usuario = _mapper.Map<Usuario>(request);
            UsuarioResponse respuesta = _mapper.Map<UsuarioResponse>(_usuarioRepository.Update(usuario));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _usuarioRepository.Delete(id);
            return true;
        }

        public List<UsuarioResponse> CreateMultiple(List<UsuarioRequest> request)
        {
            List<Usuario> usuario = _mapper.Map<List<Usuario>>(request);
            List<UsuarioResponse> respuesta = _mapper.Map<List<UsuarioResponse>>(_usuarioRepository.CreateMultiple(usuario));
            return respuesta;
        }
        public List<UsuarioResponse> UpdateMultiple(List<UsuarioRequest> request)
        {
            List<Usuario> usuario = _mapper.Map<List<Usuario>>(request);
            List<UsuarioResponse> respuesta = _mapper.Map<List<UsuarioResponse>>(_usuarioRepository.UpdateMultiple(usuario));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

        #endregion CRUD METHODS


        public VistaUsuarioRol ObtenerUsuarioByUsername(string NombreUsuario)
        {
            VistaUsuarioRol vistaUsuario = _usuarioRepository.BuscarPorNombreUsuario(NombreUsuario);
            return vistaUsuario;
        }

        public GenericFilterResponse<UsuarioResponse> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }

}
