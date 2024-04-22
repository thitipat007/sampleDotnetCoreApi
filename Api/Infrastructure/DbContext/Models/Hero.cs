namespace sampleDotnetCoreApi.Infrastructure.DbContext.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Quest> Quests { get; } = new List<Quest>();
    }
}