using Game.API.Data;
using Game.API.Models;
using Game.API.Repositories.Interfaces;

namespace Game.API.Repositories
{
    public class GameRepository : IGameRepository
    {
        private GamesContext _context;

        public GameRepository(GamesContext context) => _context = context;

        public IEnumerable<Games> GetGames() => _context.Games;
        public Games GetGame(Guid? gameId) => _context.Games.Where(x => x.Id == gameId).Single();
        public IEnumerable<GameRatings> GetGameRatings() => _context.GameRatings;
        public void SaveDetail(Games game)
        {
            if (game.Id != null)
                _context.Games.Update(game);
            else
                _context.Games.Add(game);
            _context.SaveChanges();
        }

        public List<GameSearchResultsModel> SearchGames(GameSearchModel searchRequest)
        {
            var results =
                    (from g in _context.Games
                     join gr in _context.GameRatings on g.GameRatingsId equals gr.Id into grs
                     from gr in grs.DefaultIfEmpty()
                     where ((string.IsNullOrWhiteSpace(searchRequest.Title) || g.Title.Contains(searchRequest.Title)) &&
                     (string.IsNullOrWhiteSpace(searchRequest.Description) || g.Description.Contains(searchRequest.Description)) &&
                     (searchRequest.GameRatingsId == null || g.GameRatingsId == searchRequest.GameRatingsId)
                     //(searchRequest.ReleaseYear == null || (m.ReleaseDate.HasValue && m.ReleaseDate.Value.Year == searchRequest.ReleaseYear))
                     //searchRequest.MovieGenreIds.Contains(m.MovieGenresId.Value) &&
                     //(m.MovieGenresId.HasValue && searchRequest.MovieGenreIds.Contains(m.MovieGenresId.Value)) &&
                     //(searchRequest.MovieRatingIds.Contains(m.MovieRatingsId))
                     )
                     select new GameSearchResultsModel
                     {
                         Id = g.Id,
                         Title = g.Title,
                         Description = g.Description,
                         GameRating = gr.Rating
                     })
                    .OrderByDescending(a => a.Id)
                    .Take(1000)
                    .ToList();

            return results;

        }
    }
}
