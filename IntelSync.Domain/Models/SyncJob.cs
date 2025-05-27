namespace IntelSync.Domain.Models;
public class SyncJob
{
    public int Id { get; set; }
    public CrmUser User { get; set; }
    public SyncObjectType ObjectType { get; set; }
    public string Payload { get; set; }
    public DateTime SyncTime { get; set; }
    public string SyncStatus { get; set; }
    public string ErrorMessage { get; set; }
}