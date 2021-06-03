using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LOG.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LOG.API.Repositories
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T : class
    {
        private DbContext Contexto { get; set; }
        private DbSet<T> Entidade { get; set; }
        internal bool AsNoTrackingSearchs { get; set; } = false;

        public RepositorioGenerico(DbContext contexto)
        {
            Contexto = contexto;
            Entidade = Contexto.Set<T>();
        }
        public T Criar(T obj)
        {
            try
            {
                Entidade.Add(obj);
                Contexto.SaveChanges();
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
                var entry = Contexto.Entry<T>(obj);

                if (entry != null)
                    entry.State = EntityState.Modified;

                Contexto.SaveChanges();
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
                Entidade.Remove(obj);
                Contexto.SaveChanges();
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
            IQueryable<T> query = Entidade;

            foreach (var item in expressoesLambda)
            {
                query = query.Include(item);
            }

            if (AsNoTrackingSearchs)
                return query.AsNoTracking();

            return query;
        }

        public bool CriarMultiplos(List<T> obj)
        {
            try
            {
                obj.ForEach(o => Entidade.Add(o));
                Contexto.SaveChanges();
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
