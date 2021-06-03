using System;
using System.Collections.Generic;
using System.Linq;
using LOG.API.Model;
using LOG.API.Services;
using LOG.APITests.Configs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LOG.APITests.Services
{
    [TestClass]
    public class ServicoLogTests
    {
        private static readonly FakeRepository<Log> _repoLog = new();
        private static readonly ServicoLog _srvLog = new(_repoLog);

        [TestInitialize]
        public void ServicoLogTests_Init()
        {
            _repoLog.CriarMultiplos(new List<Log>{
                new Log("{\"Teste\": \"Seed de dados 1\"}"),
                new Log("{\"Teste\": \"Seed de dados 2\"}"),
                new Log("{\"Teste\": \"Seed de dados 3\"}"),
                new Log("{\"Teste\": \"Seed de dados 4\"}"),
                new Log("{\"Teste\": \"Seed de dados 5\"}")
            });
        }

        [TestMethod]
        public void ServicoLog_Incluir_DadosJson_Null()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                _srvLog.IncluirLog(null));
        }

        [TestMethod]
        public void ServicoLog_Incluir_DadosJson_Valido()
        {
            var log = _srvLog.IncluirLog("{\"Teste\": \"Dados Json informados\"}");
            Assert.IsNotNull(log);
        }

        [TestMethod]
        public void ServicoLog_PesquisarLog_Invalido()
        {
            Assert.IsNotInstanceOfType(_srvLog.PesquisarLog(Guid.NewGuid()), typeof(Log));
        }

        [TestMethod]
        public void ServicoLog_PesquisarLog_Valido()
        {
            var idLog = _repoLog.PesquisarTodos().FirstOrDefault().Id;
            Assert.IsInstanceOfType(_srvLog.PesquisarLog(idLog), typeof(Log));
        }
    }
}