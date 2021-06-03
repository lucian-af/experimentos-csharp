using System;
using System.Linq;
using LOG.API.Interfaces;
using LOG.API.Model;

namespace LOG.API.Services
{
    public class ServicoLog
    {
        private readonly IRepositorio<Log> _repoLog;
        public ServicoLog(IRepositorio<Log> repoLog)
        {
            _repoLog = repoLog;
        }

        /// <summary>
        /// Método responsável por criar um novo Log
        /// </summary>
        /// <param name="dadosJson">json em formato de string/param>
        /// <returns>objeto Log se sucesso</returns>
        public Log IncluirLog(string dadosJson)
        {
            if (string.IsNullOrWhiteSpace(dadosJson))
                throw new ArgumentException("DadosJson não informado.");

            var log = new Log(dadosJson);

            return _repoLog.Criar(log);
        }

        /// <summary>
        /// Pesquisa um log pelo Id
        /// </summary>
        /// <param name="idLog">Id do Log</param>
        /// <returns>Log encontrado</returns>
        public Log PesquisarLog(Guid idLog)
        {
            if (idLog == Guid.Empty)
                throw new ArgumentException("IdLog não informado.");

            return _repoLog.Pesquisar(l => l.Id == idLog).FirstOrDefault();
        }
    }
}
