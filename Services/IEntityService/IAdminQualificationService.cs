using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminQualificationService
    {
        Task<QualificationDto> Get(Guid id);
        Task<bool> Update(QualificationDto qualification);
        Task<bool> Delete(QualificationDto qualification);
    }
}
