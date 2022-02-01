namespace Game.API.Models
{
    public class GameSearchResultsModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GameRating { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
