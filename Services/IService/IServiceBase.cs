namespace Services.IService
{
    public interface IServiceBase<TEntity, TDto>
    {
        Task<IQueryable<TDto>> GetAll();
        Task Add(TDto tDto);
        Task Update(TDto entityTDto);
        Task Delete(Guid entity);
        Task<TDto> GetById(Guid id);
    }
}
