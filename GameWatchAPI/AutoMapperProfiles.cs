using AutoMapper;
using GameWatchAPI.DTOs;
using GameWatchAPI.Models;

namespace GameWatchAPI
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Biznesi, GetBiznesiDTO>();
            CreateMap<Biznesi, BiznesiDTO>().ReverseMap();
            CreateMap<BiznesiKonzola, BiznesiKonzolaDTO>();
            CreateMap<BiznesiKonzolaDTO, BiznesiKonzola>();
            CreateMap<Cmimorja, CmimorjaDTO>().ReverseMap();
            CreateMap<Cmimorja, GetCmimiDTO>();
            CreateMap<Lokali, GetLokaliDTO>();
            CreateMap<Konzola, GetKonzolaDTO>();
            CreateMap<LokaliDTO, Lokali>();
            CreateMap<VideoLoja, GetVideoLojaDTO>();
            CreateMap<Fatura, UpdateFaturaDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateFaturaDTO, Fatura>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Fatura, GetFaturaDTO>();
            CreateMap<GetFaturaDTO, Fatura>();
            CreateMap<GetFaturaLokaliDTO, Fatura>();
            CreateMap<Fatura, GetFaturaLokaliDTO>();

        }
    }
}
