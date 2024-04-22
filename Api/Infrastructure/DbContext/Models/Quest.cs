namespace sampleDotnetCoreApi.Infrastructure.DbContext.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public int HeroId { get; set; }
        public string Name { get; set; }
        public Hero Hero { get; set; } = null!;
    }
}