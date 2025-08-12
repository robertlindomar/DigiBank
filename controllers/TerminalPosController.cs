using DigiBank.models;
using DigiBank.services;
using System;
using System.Collections.Generic;

namespace DigiBank.controllers
{
    public class TerminalPosController
    {
        private readonly TerminalPosService _service;

        public TerminalPosController()
        {
            _service = new TerminalPosService();
        }

        public int Criar(TerminalPos terminal)
        {
            try
            {
                return _service.CriarTerminal(terminal);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao criar terminal: {ex.Message}");
            }
        }

        public List<TerminalPos> BuscarTodos()
        {
            try
            {
                return _service.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar terminais: {ex.Message}");
            }
        }

        public TerminalPos BuscarPorId(int id)
        {
            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar terminal por ID: {ex.Message}");
            }
        }

        public TerminalPos BuscarPorUid(string uid)
        {
            try
            {
                return _service.BuscarPorUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar terminal por UID: {ex.Message}");
            }
        }

        public List<TerminalPos> BuscarPorContaId(int contaId)
        {
            try
            {
                return _service.BuscarPorContaId(contaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar terminais da conta: {ex.Message}");
            }
        }

        public List<TerminalPos> BuscarPorLocalizacao(string localizacao)
        {
            try
            {
                return _service.BuscarPorLocalizacao(localizacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar terminais por localização: {ex.Message}");
            }
        }

        public void Atualizar(TerminalPos terminal)
        {
            try
            {
                _service.AtualizarTerminal(terminal);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar terminal: {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _service.DeletarTerminal(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao deletar terminal: {ex.Message}");
            }
        }

        public bool Existe(int id)
        {
            try
            {
                return _service.ExisteTerminal(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do terminal: {ex.Message}");
            }
        }

        public bool ExisteUid(string uid)
        {
            try
            {
                return _service.ExisteUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do UID: {ex.Message}");
            }
        }

        public TerminalPos AutenticarTerminal(string uid)
        {
            try
            {
                return _service.AutenticarTerminal(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao autenticar terminal: {ex.Message}");
            }
        }
    }
}
