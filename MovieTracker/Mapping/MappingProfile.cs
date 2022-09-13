using AutoMapper;
using MovieTracker.Models.Dto;
using MovieTracker.Models.Entities;

namespace MovieTracker.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieRequest, Movie>();
            CreateMap<Movie, MovieResponse>();
            
            CreateMap<UserRegister, User>();

            CreateMap<ActorRequest, Actor>();   
            CreateMap<Actor, ActorResponse>();
            CreateMap<Actor, ActorForRoleResponse>();

            CreateMap<MovieType, MovieTypeDto>();

            CreateMap<RoleRequst, Role>();
            CreateMap<Role, RoleResonse>();
        }
    }
}
