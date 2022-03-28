using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Services.IService;
using Services.Mapping;
using Services.Service;

namespace XTestProject
{
    public class BaseTest
    {
        protected RepositoryContext _context;
        protected IMapper _mapper;
        public BaseTest(RepositoryContext context = null, IMapper mapper = null, IServiceManager service = null)
        {
            _context = context ?? GetInMemoryDBContext();
            _mapper = mapper ?? GetMapper();
        }

        private IMapper GetMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }

        private RepositoryContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;
            RepositoryContext dbContext = new RepositoryContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
