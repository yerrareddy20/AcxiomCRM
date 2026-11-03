using AcxiomCRM.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AcxiomCRM.Data
{
    public class AuditLogService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditLogService(
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogAsync(
            string action,
            string entityName,
            string? recordId = null,
            string? oldValue = null,
            string? newValue = null)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            var log = new AuditLog
            {
                UserId = httpContext?.User?
                    .FindFirstValue(ClaimTypes.NameIdentifier),

                Action = action,
                EntityName = entityName,
                RecordId = recordId,
                OldValue = oldValue,
                NewValue = newValue,
                CreatedDate = DateTime.UtcNow,
                IpAddress = httpContext?.Connection.RemoteIpAddress?.ToString()
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}