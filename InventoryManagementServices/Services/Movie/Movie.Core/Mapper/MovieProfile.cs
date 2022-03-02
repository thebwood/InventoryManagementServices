using AutoMapper;
using Movie.Core.Models;
using Movie.Infrastructure.Entities;

namespace Movie.Core.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MoviesModel, Movies>();
            CreateMap<Movies, MoviesModel>();
            CreateMap<MovieRatings, MovieRatingsModel>();
            CreateMap<MovieGenres, MovieGenresModel>();
            CreateMap<MovieSearchResults, MovieSearchResultsModel>();
            CreateMap<MovieSearchModel, MovieSearch>();
        }
    }
}
