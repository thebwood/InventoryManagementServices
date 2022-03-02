using AutoMapper;
using Game.Core.Services.Interfaces;
using Game.Infrastructure.Entities;
using Game.Infrastructure.Repositories.Interfaces;
using Game.Core.Models;
using InventoryManagement.Web.Base.Services;
using Microsoft.Extensions.Logging;

namespace Game.Core.Services
{
    public class GameService : InventoryManagementServices<GameService>, IGameService
    {
        private IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(ILogger<GameService> logger, IGameRepository repo, IMapper mapper) : base(logger)
        {
            _gameRepository = repo;
            _mapper = mapper;
        }

        public IEnumerable<GamesModel> GetGames()
        {
            var games = _gameRepository.GetGames();
            IEnumerable<GamesModel> gamesModel = new List<GamesModel>();

            _mapper.Map(games, gamesModel);
            return gamesModel;
        }
        public GamesModel GetGame(Guid? gameId)
        {
            var game = _gameRepository.GetGame(gameId);
            var gameModel = new GamesModel();

            _mapper.Map(game, gameModel);

            return gameModel;
        }

        public IEnumerable<GameRatingsModel> GetGameRatings()
        {
            var gameRatings = _gameRepository.GetGameRatings();
            IEnumerable<GameRatingsModel> gameRatingsModel = new List<GameRatingsModel>();
            _mapper.Map(gameRatings, gameRatingsModel);
            return gameRatingsModel;

        }

        public List<GameSearchResultsModel> SearchGames(GameSearchModel searchRequestModel)
        {
            var searchRequest = new GameSearch();
            var gameSearchResults = new List<GameSearchResultsModel>();
            _mapper.Map(searchRequestModel, searchRequest);
            var results = _gameRepository.SearchGames(searchRequest);
            _mapper.Map(results, gameSearchResults);

            return gameSearchResults;
        } 

        public List<string> SaveDetail(GamesModel Game)
        {
            var errors = ValidateGame(Game);
            if (errors.Count() == 0)
            {
                var existingGame = new Games();
                if (Game.Id != null)
                    existingGame = _gameRepository.GetGame(Game.Id);

                _mapper.Map<GamesModel, Games>(Game, existingGame);
                _gameRepository.SaveDetail(existingGame);
            }

            return errors;
        }

        private List<string> ValidateGame(GamesModel game)
        {
            var errors = new List<string>();

            if (String.IsNullOrWhiteSpace(game.Title))
            {
                errors.Add("Title is required");
            }
            if (String.IsNullOrWhiteSpace(game.Description))
            {
                errors.Add("Description is required");
            }


            return errors;
        }
    }
}
