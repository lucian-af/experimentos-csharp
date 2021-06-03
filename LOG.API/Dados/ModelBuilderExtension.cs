using System;
using System.Linq;
using System.Reflection;
using LOG.API.Model;
using Microsoft.EntityFrameworkCore;

namespace LOG.API.Dados
{
    public static class ModelBuilderExtension
    {

        public static void MapLog(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .ToTable("log")
                .HasKey(l => l.Id);

            modelBuilder.Entity<Log>()
                .Property(l => l.DadosJson)
                .HasColumnName("dadosjson")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            modelBuilder.Entity<Log>()
                .Property(l => l.DataHora)
                .HasColumnName("datahora")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }

    public static class HelperModelBuilderExtension
    {
        public static void MapAll(this ModelBuilder modelBuilder, Type classe)
        {
            MethodInfo[] methodInfo = classe.GetMethods(BindingFlags.Public | BindingFlags.Static);

            if (methodInfo.Any(m => m.GetParameters().Count() != 1 || m.GetParameters().Any(g => g.ParameterType != typeof(ModelBuilder))))
                throw new InvalidOperationException("Classe com mapeamento incorreto.");

            foreach (var method in methodInfo)
            {
                method.Invoke(null, new object[] { modelBuilder });
            }
        }
    }
}
