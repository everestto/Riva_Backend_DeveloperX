using IntelSync.Domain.Models;
using IntelSync.Domain.Services;


var jobs = new List<SyncJob>
{
    new SyncJob
    {
        Id = 1,
        User = new CrmUser
        {
            Email = "alice@example.com",
            Platform = "Salesforce",
            Token = "token123"
        },
        ObjectType = SyncObjectType.Contact,
        Payload = "{ \"email\": \"alice@example.com\", \"name\": \"Alice\" }",
        SyncTime = DateTime.UtcNow
    },
    new SyncJob
    {
        Id = 2,
        User = new CrmUser
        {
            Email = "john@example.com",
            Platform = "Outlook",
            Token = null
        },
        ObjectType = SyncObjectType.Meeting,
        Payload = "{ \"title\": \"Team Sync\" }",
        SyncTime = DateTime.UtcNow
    }
};

var validator = new SimpleTokenValidator();
var processor = new BatchSyncProcessor(validator);
processor.ProcessAll(jobs);
