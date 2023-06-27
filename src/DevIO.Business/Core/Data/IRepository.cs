using DevIO.Business.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Core.Data {

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity {

        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
       /// <summary>
       /// Método recebe uma expressão lambda como parâmetro.
       /// </summary>
       /// <param name="predicate"></param>
       /// <returns></returns>
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Método retorna o número de linhas afetadas no banco de dados.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChanges();
    }
}
