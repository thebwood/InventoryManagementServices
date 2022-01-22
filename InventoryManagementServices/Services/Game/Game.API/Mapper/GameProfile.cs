using AutoMapper;
using Game.API.Data;
using Game.API.Models;

namespace Game.API.Mapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Games, GamesModel>();
            CreateMap<GamesModel, Games>();
            CreateMap<GameRatings, GameRatingsModel>();
        }
    }
}
