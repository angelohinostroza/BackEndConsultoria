using AutoMapper;
using DbConsultoriaModel.dbConsultoria;
using IBussnies;
using IRepository;
using Repository;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UtilSecurity;

namespace Bussnies
{
    public class AuthBussnies: IAuthBussnies
    {
        #region declaracion de variables y constructor
    
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly UtilEncriptDecript _cripto;

        public AuthBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = new UsuarioRepository();
            _cripto = new UtilEncriptDecript();
        }
        #endregion declaracion de variables y constructor

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse loginResponse = new LoginResponse();

            VistaUsuarioRol vistaUsuario = _usuarioRepository.BuscarPorNombreUsuario(request.NombreUsuario);

            string newPassword = _cripto.Encriptar_AES(request.Password);

            if (vistaUsuario != null && vistaUsuario.Password == newPassword)
            {

                loginResponse.Success = true;
                loginResponse.Message = "LOGIN CORRECTO";
                loginResponse.NombresEmpleado = vistaUsuario.Nombres;
                loginResponse.NombreRol = vistaUsuario.NombreRol;
                loginResponse.Token = "";


                //implementar el automapper
                loginResponse.Usuario.IdRol = vistaUsuario.IdRol;
                loginResponse.Usuario.IdUsuario = vistaUsuario.IdUsuario;
                loginResponse.Usuario.NombreUsuario = request.NombreUsuario;
                loginResponse.Usuario.IdEmpleado = vistaUsuario.IdEmpleado;
                loginResponse.Usuario.Email = vistaUsuario.Email;

                return loginResponse;

                
            }


            return loginResponse;
        }
    }
}