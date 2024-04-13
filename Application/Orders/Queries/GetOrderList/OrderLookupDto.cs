using Application.Common.Mapping;
using AutoMapper;
using Domain;

namespace Application.Orders.Queries.GetOrder
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public string Description {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>()
                .ForMember(orderDto => orderDto.Id,
                    opt => opt.MapFrom(order => order.Id))
                .ForMember(orderDto => orderDto.Description,
                    opt => opt.MapFrom(order => order.Description))
                ;
        }
    }
}
