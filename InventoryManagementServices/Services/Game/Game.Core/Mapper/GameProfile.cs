using AutoMapper;
using Game.Infrastructure.Entities;
using Game.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Mapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Games, GamesModel>();
            CreateMap<GamesModel, Games>();
            CreateMap<GameSearchModel, GameSearch>();
            CreateMap<GameSearchResults, GameSearchResultsModel> ();
            CreateMap<GameRatings, GameRatingsModel>();
        }
    }
}
