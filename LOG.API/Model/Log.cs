using System;
using Newtonsoft.Json;

namespace LOG.API.Model
{
    public class Log
    {
        public Log(string dadosJson)
        {
            Id = Guid.NewGuid();
            DadosJson = JsonConvert.SerializeObject(dadosJson);
            DataHora = DateTime.Now;
        }

        public Guid Id { get; }
        public string DadosJson { get; }
        public DateTime DataHora { get; }
    }
}
