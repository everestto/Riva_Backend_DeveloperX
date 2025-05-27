using IntelSync.Domain.Models;

namespace IntelSync.Domain.Services;
public interface ISyncValidator
{
    bool Validate(SyncJob job, out string errorMessage);
}
