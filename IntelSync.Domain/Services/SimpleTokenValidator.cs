using IntelSync.Domain.Models;

namespace IntelSync.Domain.Services;
public class SimpleTokenValidator : ISyncValidator
{
    public bool Validate(SyncJob job, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(job?.User?.Token))
        {
            errorMessage = "Missing CRM token.";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }
}
