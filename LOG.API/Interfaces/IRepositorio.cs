using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LOG.API.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        /// <summary>
        /// Método responsável por adicionar um objeto do banco de dados
        /// </summary>
        /// <param name="obj">Objeto a ser adicionado</param>
        /// <returns>Objeto inserido</returns>
        public T Criar(T obj);

        /// <summary>
        /// Método responsável por adicionar um objeto do banco de dados
        /// </summary>
        /// <param name="obj">Objeto a ser adicionado</param>
        /// <returns>Objeto inserido</returns>
        public bool CriarMultiplos(List<T> obj);

        /// <summary>
        /// Método responsável por alterar um objeto do banco de dados
        /// </summary>
        /// <param name="obj">Objeto a ser alterado</param>
        /// <returns>Objeto alterado</returns>
        public T Alterar(T obj);

        /// <summary>
        /// Método responsável por remover um objeto do banco de dados
        /// </summary>
        /// <param name="obj">Objeto a ser removido</param>
        /// <returns>Verdadeiro se sucesso</returns>
        public bool Remover(T obj);

        /// <summary>
        /// Método responsável por pesquisar objetos no banco de dados
        /// </summary>
        /// <param name="predicado">Parâmetro Obrigatório</param>
        /// <param name="expressoesLambda">Parâmetro Opcional</param>
        /// <returns>Lista encontrada com base na pesquisa passada via parâmetros</returns>
        public IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] expressoesLambda);

        /// <summary>
        /// Método responsável por pesquisar objetos no banco de dados
        /// </summary>
        /// <param name="predicado">Parâmetro Obrigatório</param>
        /// <param name="expressoesLambda">Parâmetro Opcional</param>
        /// <returns>Lista encontrada com base na pesquisa passada via parâmetros</returns>
        public IQueryable<T> PesquisarTodos(params Expression<Func<T, object>>[] expressoesLambda);
    }
}
