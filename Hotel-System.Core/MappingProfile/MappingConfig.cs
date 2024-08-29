using AutoMapper;
using Hotel_System.Core.Domain.Entites;
using Hotel_System.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
           
            CreateMap<VillaAddRequest, Villa>().ReverseMap();
            CreateMap<VillaUpdateRequest, Villa>().ReverseMap();
            CreateMap<VillaResponse, Villa>().ReverseMap();
            CreateMap<VillaAddRequest, VillaResponse>().ReverseMap();
            CreateMap<VillaUpdateRequest, VillaResponse>().ReverseMap();
            CreateMap<Villa, Villa>();
            CreateMap<VillaNumber, VillaNumber>();
            CreateMap<VillaNumberAddRequest, VillaNumber>().ReverseMap();
            CreateMap<VillaNumberUpdateRequest, VillaNumber>().ReverseMap();
            CreateMap<VillaNumberUpdateRequest , VillaResponse>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberResponse>()
            .ForMember(dest => dest.VillaName, opt => opt.MapFrom(src => src.Villa.VillaName)).ReverseMap();
            CreateMap<VillaNumberAddRequest , VillaNumberResponse>().ReverseMap();
        }
    }
}
