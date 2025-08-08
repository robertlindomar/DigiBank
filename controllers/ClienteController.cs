using DigiBank.models;
using DigiBank.repositories;
using DigiBank.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.controllers
{
    public class ClienteController
    {
        private readonly ClienteService service;

        public ClienteController()
        {
            service = new ClienteService();
        }


        public void criar(Cliente cliente)
        {

            service.CadastrarCliente(cliente);
        }

        public List<Cliente> BuscarTodos()
        {
            return service.BuscarTodos();
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            return service.BuscarPorCpf(cpf);
        }

        public Cliente BuscarPorId(int id)
        {
            return service.BuscarPorId(id);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            service.AtualizarCliente(cliente);
        }

        public void DeletarCliente(int id)
        {
            service.DeletarCliente(id);
        }

    }
}
