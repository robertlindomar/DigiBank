using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.models;
using DigiBank.repositories;

namespace DigiBank.services
{
    public class ContaService
    {
        private readonly ContaRepository repository;

        public ContaService()
        {
            repository = new ContaRepository();
        }

        public int CriarConta(Conta novaConta)
        {
            if (novaConta == null)
            {
                throw new ArgumentNullException(nameof(novaConta), "A conta não pode ser nula.");
            }

            if (string.IsNullOrEmpty(novaConta.NumeroConta))
            {
                throw new ArgumentException("O número da conta não pode ser vazio.", nameof(novaConta.NumeroConta));
            }

            if (novaConta.ClienteId <= 0)
            {
                throw new ArgumentException("O ID do cliente deve ser maior que zero.", nameof(novaConta.ClienteId));
            }

            return repository.Criar(novaConta);
        }

        public Conta BuscarPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID da conta deve ser maior que zero.", nameof(id));
            }

            var conta = repository.BuscarPorId(id);
            if (conta == null)
            {
                throw new ArgumentException("Conta não encontrada.", nameof(id));
            }

            return conta;
        }

        public Conta BuscarPorNumero(string numeroConta)
        {
            if (string.IsNullOrEmpty(numeroConta))
            {
                throw new ArgumentException("O número da conta não pode ser vazio.", nameof(numeroConta));
            }

            var conta = repository.BuscarPorNumero(numeroConta);

            if (conta == null)
            {
                throw new ArgumentException("Conta não encontrada.", nameof(numeroConta));
            }

            return conta;
        }

        public Conta AtualizarConta(Conta contaAtualizada)
        {
            if (contaAtualizada == null)
            {
                throw new ArgumentNullException(nameof(contaAtualizada), "A conta não pode ser nula.");
            }

            if (string.IsNullOrEmpty(contaAtualizada.NumeroConta))
            {
                throw new ArgumentException("O número da conta não pode ser vazio.", nameof(contaAtualizada.NumeroConta));
            }

            if (contaAtualizada.ClienteId <= 0)
            {
                throw new ArgumentException("O ID do cliente deve ser maior que zero.", nameof(contaAtualizada.ClienteId));
            }

            return repository.Atualizar(contaAtualizada);
        }

        public List<Conta> BuscarTodas()
        {
            return repository.BuscarTodas();
        }

        public List<Conta> BuscarPorClienteId(int numeroConta)
        {
            return repository.BuscarPorClienteId(numeroConta);
        }

        public void DeletarConta(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID da conta deve ser maior que zero.", nameof(id));
            }
            var conta = repository.BuscarPorId(id);
            if (conta == null)
            {
                throw new ArgumentException("Conta não encontrada.", nameof(id));
            }

            repository.Deletar(id);
        }


    }
}
