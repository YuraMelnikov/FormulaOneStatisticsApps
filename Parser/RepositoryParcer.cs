using Entities.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Parser
{
    public class RepositoryParcer : RepositoryContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=Cosworth3_;Server=localhost;Port=5432;Database=postgres;Integrated Security=true;Pooling=true;");
        }
    }
}
