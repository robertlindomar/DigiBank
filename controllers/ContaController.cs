using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.models;
using DigiBank.services;

namespace DigiBank.controllers
{
    public class ContaController
    {
        private readonly ContaService contaService;

        public ContaController()
        {
            contaService = new ContaService();
        }

        public int CriarConta(Conta novaConta)
        {
            return contaService.CriarConta(novaConta);
        }

        public List<Conta> BuscarTodasContas()
        {
            return contaService.BuscarTodas();
        }



        public Conta BuscarContaPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID da conta deve ser maior que zero.", nameof(id));
            }
            return contaService.BuscarPorId(id);
        }

        public List<Conta> BuscarPorClienteId(int id)
        {
            return contaService.BuscarPorClienteId(id);
        }


        public Conta BuscarContaPorNumero(string numeroConta)
        {
            if (string.IsNullOrEmpty(numeroConta))
            {
                throw new ArgumentException("O número da conta não pode ser vazio.", nameof(numeroConta));
            }
            return contaService.BuscarPorNumero(numeroConta);
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

            return contaService.AtualizarConta(contaAtualizada);
        }

        public void DeletarConta(int id)
        {
            contaService.DeletarConta(id);
        }











    }
}
