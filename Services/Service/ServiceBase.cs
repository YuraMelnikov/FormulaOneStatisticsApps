using Microsoft.EntityFrameworkCore;
using Entities.Contexts;
using Entities.Common;
using Services.IService;
using Services.DTO.Common;
using AutoMapper;

namespace Services.Service
{
    public class ServiceBase<TEntity, TDto> : IServiceBase<TEntity, TDto> where TDto : EntityDto where TEntity : Entity
    {
        protected readonly RepositoryContext _repositoryContext;
        protected readonly IMapper _mapper;

        public ServiceBase(RepositoryContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public IQueryable<TDto> GetAll()
        {
            var entity = _repositoryContext.Set<TEntity>().AsNoTracking();
            var res = _mapper.Map<IEnumerable<TDto>>(entity);
            return res.AsQueryable();
        }
            
        public Task Add(TDto tDto) 
        {
            var entity = _mapper.Map<TEntity>(tDto);
            _repositoryContext.Set<TEntity>().Add(entity);
            return Task.CompletedTask;
        }

        public Task Update(TDto entityTDto)
        {
            var entity = _mapper.Map<TEntity>(entityTDto);
            _repositoryContext.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            var entity = _repositoryContext.Set<TEntity>().Find(id);
            if(entity != null)
                _repositoryContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<TDto> GetById(Guid id) 
        {
            var entity = await _repositoryContext.Set<TEntity>().FindAsync(id);
            return _mapper.Map<TDto>(entity);
        }
    }
}
