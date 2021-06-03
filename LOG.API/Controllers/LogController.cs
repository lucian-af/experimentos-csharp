using System;
using LOG.API.Model;
using LOG.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LOG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ServicoLog _srvLog;
        public LogController(ServicoLog srvLog)
        {
            _srvLog = srvLog;
        }

        [HttpPost]
        /// <summary>
        /// Cria um novo Log
        /// </summary>
        /// <param name="dadosJson">dados do log</param>
        /// <returns>Log criado se sucesso</returns>                
        public Log Post(string dadosJson)
        {
            return _srvLog.IncluirLog(dadosJson);
        }

        [HttpGet]
        /// <summary>
        /// Cria um novo Log
        /// </summary>
        /// <param name="dadosJson">dados do log</param>
        /// <returns>Log criado se sucesso</returns>                
        public Log Get(Guid idLog)
        {
            return _srvLog.PesquisarLog(idLog);
        }
    }
}
