namespace Repository.IService
{
    public interface IRepositoryBase<TEntity, TDto>
    {
        IQueryable<TDto> GetAll();
        Task Add(TDto tDto);
        Task Update(TDto entityTDto);
        Task Delete(Guid entity);
        Task<TDto> GetById(Guid id);
    }
}
