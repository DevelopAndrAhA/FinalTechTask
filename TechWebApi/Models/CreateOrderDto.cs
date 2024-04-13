using Application.Common.Mapping;
using Application.Orders.Commands.CreateOrder;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TechWebApi.Models
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        [Required]
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(ordCommand => ordCommand.Description,
                opt => opt.MapFrom(ordDto => ordDto.Description));
        }
    }
}
