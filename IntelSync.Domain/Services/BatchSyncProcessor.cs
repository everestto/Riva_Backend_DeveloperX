using IntelSync.Domain.Models;

namespace IntelSync.Domain.Services;
public class BatchSyncProcessor
{
    private readonly ISyncValidator validator;

    public BatchSyncProcessor(ISyncValidator validator)
    {
        this.validator = validator;
    }

    public void ProcessAll(IEnumerable<SyncJob> jobs)
    {
        foreach (var job in jobs)
        {
            Console.WriteLine($"Processing {job.ObjectType} for {job.User.Email} on {job.User.Platform}...");

            if (!validator.Validate(job, out var errorMessage))
            {
                job.SyncStatus = "Failed";
                job.ErrorMessage = errorMessage;
                Console.WriteLine($"[FAIL] {errorMessage}");
            }
            else
            {
                job.SyncStatus = "Success";
                job.ErrorMessage = string.Empty;
                Console.WriteLine("[SUCCESS] Sync completed successfully.");
            }
        }
    }
}
