using Services.DTO.Common;

namespace Services.IEntityService
{
    public interface IAdminCRU<T> where T : EntityDto
    {
        Task<IEnumerable<T>> Get();
        Task<T?> GetById(Guid Id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete (Guid entity);
    }
}