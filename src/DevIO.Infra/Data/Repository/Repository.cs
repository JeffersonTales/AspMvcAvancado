using DevIO.Business.Core.Data;
using DevIO.Business.Core.Models;
using DevIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository {
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() {

        #region Atributos
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        #endregion

        #region Construtor
        protected Repository() {
            this.Db = new MeuDbContext();
            this.DbSet = this.Db.Set<TEntity>(); //acesso aos funcionamentos da entidade
        }
        #endregion

        #region Metodos de Contrato
        public virtual async Task Adicionar(TEntity entity) {
            this.DbSet.Add(entity);
            await this.SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity) {
            this.Db.Entry(entity).State = EntityState.Modified;
            await this.SaveChanges();
        }

        public virtual async Task Remover(Guid id) {
            //this.DbSet.Remove(await this.DbSet.FindAsync(id)); -> poderia ser assim também
            this.Db.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public virtual async Task<int> SaveChanges() {
            return await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) {
            //AsNoTraking desabilita o tracker do EF -o EF fica 'observando' a entidade para saber se mudou, etc.
            return await this.DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id) {
            return await this.DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos() {
            return await this.DbSet.ToListAsync();
        }

        public void Dispose() {
            this.Db?.Dispose();
        }
        #endregion
    }
}
