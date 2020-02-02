using Core.Data.Interfaces.Entitys;

namespace Core.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class, IBaseEntity
    {
    }
}
