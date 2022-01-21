namespace Game.API.Models
{
    public class GameSearchModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? ReleaseYear { get; set; }
        public Guid? GameRatingsId { get; set; }
        public List<Guid> GameTypeIds { get; set; }

    }
}
