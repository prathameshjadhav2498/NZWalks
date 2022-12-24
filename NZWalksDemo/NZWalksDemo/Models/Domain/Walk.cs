namespace NZWalksDemo.Models.Domain
{
    public class Walk : AuditEntity
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Region Region { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
