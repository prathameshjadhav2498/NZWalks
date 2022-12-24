namespace NZWalksDemo.Models.Domain
{
    public class WalkDifficulty : AuditEntity
    {
        public string Code { get; set; }
        public IEnumerable<Walk> Walks { get; set; }
    }
}
