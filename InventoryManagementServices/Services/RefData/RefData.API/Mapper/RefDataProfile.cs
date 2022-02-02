using AutoMapper;
using RefData.API.Data;
using RefData.API.Models;

namespace RefData.API.Mapper
{
    public class RefDataProfile : Profile
    {
        public RefDataProfile()
        {
            CreateMap<Genre, GenreModel>();
        }

    }
}
