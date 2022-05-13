using Services.DTOCRUD;

namespace Services.IEntityService
{
    public interface IAdminQualification
    {
        Task<QualificationDto> Get(Guid id);
        Task<bool> Update(QualificationDto qualification);
    }
}
