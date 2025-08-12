using DigiBank.models;
using DigiBank.repositories;
using System;
using System.Collections.Generic;

namespace DigiBank.services
{
    public class TerminalPosService
    {
        private readonly TerminalPosRepository _repository;
        private readonly ContaService _contaService;

        public TerminalPosService()
        {
            _repository = new TerminalPosRepository();
            _contaService = new ContaService();
        }

        public int CriarTerminal(TerminalPos novoTerminal)
        {
            try
            {
                ValidarTerminal(novoTerminal);
                
                // Verificar se a conta existe
                if (!_contaService.ExisteConta(novoTerminal.ContaId))
                {
                    throw new Exception("Conta não encontrada.");
                }

                // Verificar se o UID já existe
                if (_repository.ExisteUid(novoTerminal.Uid))
                {
                    throw new Exception("UID do terminal já existe.");
                }

                return _repository.Criar(novoTerminal);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar terminal: {ex.Message}");
            }
        }

        public List<TerminalPos> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar terminais: {ex.Message}");
            }
        }

        public TerminalPos BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                return _repository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar terminal por ID: {ex.Message}");
            }
        }

        public TerminalPos BuscarPorUid(string uid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uid))
                    throw new ArgumentException("UID não pode ser vazio.");

                return _repository.BuscarPorUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar terminal por UID: {ex.Message}");
            }
        }

        public List<TerminalPos> BuscarPorContaId(int contaId)
        {
            try
            {
                if (contaId <= 0)
                    throw new ArgumentException("ID da conta deve ser maior que zero.");

                return _repository.BuscarPorContaId(contaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar terminais da conta: {ex.Message}");
            }
        }

        public List<TerminalPos> BuscarPorLocalizacao(string localizacao)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(localizacao))
                    throw new ArgumentException("Localização não pode ser vazia.");

                return _repository.BuscarPorLocalizacao(localizacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar terminais por localização: {ex.Message}");
            }
        }

        public void AtualizarTerminal(TerminalPos terminal)
        {
            try
            {
                ValidarTerminal(terminal);
                
                var existente = _repository.BuscarPorId(terminal.Id);
                if (existente == null)
                {
                    throw new Exception("Terminal não encontrado.");
                }

                // Verificar se o UID já existe em outro terminal
                var terminalComUid = _repository.BuscarPorUid(terminal.Uid);
                if (terminalComUid != null && terminalComUid.Id != terminal.Id)
                {
                    throw new Exception("UID já existe para outro terminal.");
                }

                _repository.Atualizar(terminal);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar terminal: {ex.Message}");
            }
        }

        public void DeletarTerminal(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var terminal = _repository.BuscarPorId(id);
                if (terminal == null)
                {
                    throw new Exception("Terminal não encontrado.");
                }

                _repository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar terminal: {ex.Message}");
            }
        }

        public bool ExisteTerminal(int id)
        {
            try
            {
                return _repository.BuscarPorId(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do terminal: {ex.Message}");
            }
        }

        public bool ExisteUid(string uid)
        {
            try
            {
                return _repository.ExisteUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do UID: {ex.Message}");
            }
        }

        public TerminalPos AutenticarTerminal(string uid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uid))
                    throw new ArgumentException("UID não pode ser vazio.");

                var terminal = _repository.BuscarPorUid(uid);
                if (terminal == null)
                {
                    throw new Exception("Terminal não encontrado.");
                }

                return terminal;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao autenticar terminal: {ex.Message}");
            }
        }

        private void ValidarTerminal(TerminalPos terminal)
        {
            if (terminal == null)
                throw new ArgumentNullException(nameof(terminal), "Terminal não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(terminal.NomeLoja))
                throw new ArgumentException("Nome da loja é obrigatório.");

            if (string.IsNullOrWhiteSpace(terminal.Localizacao))
                throw new ArgumentException("Localização é obrigatória.");

            if (string.IsNullOrWhiteSpace(terminal.Uid))
                throw new ArgumentException("UID é obrigatório.");

            if (terminal.ContaId <= 0)
                throw new ArgumentException("ID da conta deve ser maior que zero.");

            if (terminal.NomeLoja.Length < 3)
                throw new ArgumentException("Nome da loja deve ter pelo menos 3 caracteres.");

            if (terminal.Localizacao.Length < 3)
                throw new ArgumentException("Localização deve ter pelo menos 3 caracteres.");

            if (terminal.Uid.Length < 5)
                throw new ArgumentException("UID deve ter pelo menos 5 caracteres.");
        }
    }
}
