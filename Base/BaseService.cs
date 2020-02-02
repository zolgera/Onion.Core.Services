using Core.Data.Entitys;
using Core.Data.Interfaces.Entitys;
using Core.Repository.Interfaces;
using Core.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseAuditClass, IBaseEntity
    {
        protected readonly IRepository<TEntity> _repositry;
        public BaseService(IRepository<TEntity> repositry)
        {
            _repositry = repositry;
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> result = await _repositry.GetAllAsync();
            return result;
        }
        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> filter)
        {
            IEnumerable<TEntity> result = await _repositry.FindAsync(filter);
            return result;
        }
        public virtual async Task<TEntity> Get(Guid id)
        {
            TEntity result = await _repositry.GetAsync(id);
            return result;
        }
        public virtual async Task<TEntity> Insert(TEntity model)
        {
            TEntity result = await _repositry.InsertAsync(model);
            return result;
        }
        public virtual async Task<TEntity> Update(TEntity model)
        {
            TEntity result = await _repositry.UpdateAsync(model);
            return result;
        }
        public virtual async Task Delete(TEntity model)
        {
            await _repositry.DeleteAsync(model);
        }
    }
}
