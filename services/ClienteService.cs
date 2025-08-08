using DigiBank.models;
using DigiBank.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.services
{
    public class ClienteService
    {

        private readonly ClienteRepository repository;

        public ClienteService()
        {
            repository = new ClienteRepository();
        }

        public int CadastrarCliente(Cliente novoCliente)
        {
            var existente = repository.BuscarPorCpf(novoCliente.Cpf);
            if (existente != null)
            {
                throw new Exception("CPF já cadastrado.");
            }


            return repository.Criar(novoCliente);
        }

        public List<Cliente> BuscarTodos()
        {
            return repository.BuscarTodos();
        }

        public Cliente BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public Cliente BuscarPorCpf(string cpf)
        {
            return repository.BuscarPorCpf(cpf);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            repository.Atualizar(cliente);
        }

        public void DeletarCliente(int id)
        {
            repository.Deletar(id);
        }





    }
}
