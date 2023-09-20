﻿using AutoMapper;
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
    public class ClienteBussnies : IClienteBussnies
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = new ClienteRepository();
        }
        public List<ClienteResponse> GetAll() 
        {
            List<ClienteResponse> result = _mapper.Map<List<ClienteResponse>>(_clienteRepository.GetAll());
            return result;
        }

        public ClienteResponse GetById(int id)
        {
            Cliente cliente = _clienteRepository.GetById(id);
            ClienteResponse result = _mapper.Map<ClienteResponse>(cliente);
            return result;
        }

        public ClienteResponse Create(ClienteRequest request)
        {
            Cliente cliente = _mapper.Map<Cliente>(request);
            ClienteResponse respuesta = _mapper.Map<ClienteResponse>(_clienteRepository.Create(cliente));
            return respuesta;
        }
        public ClienteResponse Update(ClienteRequest request)
        {
            Cliente cliente = _mapper.Map<Cliente>(request);
            ClienteResponse respuesta = _mapper.Map<ClienteResponse>(_clienteRepository.Update(cliente));
            return respuesta;
        }

        public bool Delete(object id)
        {
            _clienteRepository.Delete(id);
            return true;
        }
        public List<ClienteResponse> CreateMultiple(List<ClienteRequest> request)
        {
            List<Cliente> cliente = _mapper.Map<List<Cliente>>(request);
            List<ClienteResponse> respuesta = _mapper.Map<List<ClienteResponse>>(_clienteRepository.CreateMultiple(cliente));
            return respuesta;
        }

        public List<ClienteResponse> UpdateMultiple(List<ClienteRequest> request)
        {
            List<Cliente> cliente = _mapper.Map<List<Cliente>>(request);
            List<ClienteResponse> respuesta = _mapper.Map<List<ClienteResponse>>(_clienteRepository.UpdateMultiple(cliente));
            return respuesta;
        }

        public bool DeleteMultiple(object id)
        {
            throw new NotImplementedException();
        }

    }
}
