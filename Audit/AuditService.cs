using Core.Services.Interfaces;
using Core.Data.Interfaces.Audit;
using Microsoft.AspNetCore.Http;
using System;

namespace Core.Services.Audit
{
    public class AuditService : IAuditService
    {
        private readonly IHttpContextAccessor accessor;
        public AuditService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }
        public IAuditable StampCreated(IAuditable model)
        {
            model.Created = DateTime.UtcNow;
            model.CreatedBy = accessor.HttpContext.User?.Identity?.Name;
            return model;
        }
        public IAuditable StampModifed(IAuditable model)
        {
            model.Modified = DateTime.UtcNow;
            model.ModifiedBy = accessor.HttpContext.User?.Identity?.Name;
            return model;
        }
    }
}
