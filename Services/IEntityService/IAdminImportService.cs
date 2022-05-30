using Microsoft.AspNetCore.Http;

namespace Services.IEntityService
{
    public interface IAdminImportService
    {
        bool ImportData(IFormFile file);
    }
}
