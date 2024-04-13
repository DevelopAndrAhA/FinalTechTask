using Application.Common.Mapping;
using Application.Orders.Commands.UpdateOrder;
using Application.Products.Commands.UpdateProduct;
using AutoMapper;

namespace TechWebApi.Models
{
    public class UpdateOrderDto : IMapWith<UpdateOrderCommand>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>()
                .ForMember(orderCommand => orderCommand.Id,
                    opt => opt.MapFrom(orderDto => orderDto.Id))
                .ForMember(orderCommand => orderCommand.Description,
                    opt => opt.MapFrom(orderDto => orderDto.Description));
        }

    }
}
