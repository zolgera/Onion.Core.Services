using Core.Data.Interfaces.Audit;

namespace Core.Services.Interfaces
{
    public interface IAuditService
    {
        IAuditable StampCreated(IAuditable model);
        IAuditable StampModifed(IAuditable model);
    }
}