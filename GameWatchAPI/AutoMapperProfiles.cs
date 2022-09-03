using AutoMapper;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;

namespace GameWatchAPI
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Fatura, UpdateFaturaDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateFaturaDTO, Fatura>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
