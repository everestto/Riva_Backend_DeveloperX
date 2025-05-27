using IntelSync.Domain.Models;
using IntelSync.Domain.Services;
using System.Text.Json;

const string aliceEmail = "alice@example.com";

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
        Payload=JsonSerializer.Serialize(new ContactPayload { Email = aliceEmail, Name = "Alice" }),
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
        Payload=JsonSerializer.Serialize(new MeetingPayload { Title = "Team Sync" }),
        SyncTime = DateTime.UtcNow
    }
};

var validator = new SimpleTokenValidator();
var processor = new BatchSyncProcessor(validator);
processor.ProcessAll(jobs);
