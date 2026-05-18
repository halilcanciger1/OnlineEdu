using AutoMapper;
using OnlineEdu.DTO.DTOs.MassageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping() 
        {
            CreateMap<CreateMassageDto , Message>().ReverseMap();
            CreateMap<UpdateMassageDto , Message>().ReverseMap();
        }
    }
}
