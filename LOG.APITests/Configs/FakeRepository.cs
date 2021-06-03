using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using LOG.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LOG.APITests.Configs
{
    public class FakeRepository<T> : IRepositorio<T> where T : class
    {
        private ObservableCollection<T> Dados { get; set; }
        internal bool AsNoTrackingSearchs { get; set; } = false;

        public FakeRepository()
        {
            Dados = new ObservableCollection<T>();
        }
        public T Criar(T obj)
        {
            try
            {
                Dados.Add(obj);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(
                    $@"Falha ao criar o objeto do tipo {typeof(T).Name}.
                              {Environment.NewLine}
                              Detalhes técnicos: 
                              {Environment.NewLine}
                              {ex.Message}
                              {Environment.NewLine}
                              Dados: {ex.Data}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha não prevista. Detalhes: {ex.Message}");
            }

            return obj;
        }

        public T Alterar(T obj)
        {
            try
            {
                if (!Dados.Contains(obj))
                    Criar(obj);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(
                    $@"Falha ao alterar o objeto do tipo {typeof(T).Name}.
                              {Environment.NewLine}
                              Detalhes técnicos: 
                              {Environment.NewLine}
                              {ex.Message}
                              {Environment.NewLine}
                              Dados: {ex.Data}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha não prevista. Detalhes: {ex.Message}");
            }

            return obj;
        }

        public bool Remover(T obj)
        {
            try
            {
                Dados.Remove(obj);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(
                    $@"Falha ao remover o objeto do tipo {typeof(T).Name}.
                              {Environment.NewLine}
                              Detalhes técnicos: 
                              {Environment.NewLine}
                              {ex.Message}
                              {Environment.NewLine}
                              Dados: {ex.Data}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha não prevista. Detalhes: {ex.Message}");
            }

            return true;
        }

        public IEnumerable<T> Pesquisar(
            Expression<Func<T, bool>> predicado,
            params Expression<Func<T, object>>[] expressoesLambda)
                => PesquisarTodos(expressoesLambda).Where(predicado);

        public IQueryable<T> PesquisarTodos(params Expression<Func<T, object>>[] expressoesLambda)
        {
            return Dados.AsQueryable();
        }

        public bool CriarMultiplos(List<T> obj)
        {
            try
            {
                obj.ForEach(o => Dados.Add(o));
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(
                    $@"Falha ao criar o objeto do tipo {typeof(T).Name}.
                              {Environment.NewLine}
                              Detalhes técnicos: 
                              {Environment.NewLine}
                              {ex.Message}
                              {Environment.NewLine}
                              Dados: {ex.Data}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha não prevista. Detalhes: {ex.Message}");
            }

            return true;
        }
    }
}
