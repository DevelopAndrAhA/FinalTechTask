using Application.Common.Mapping;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(orderVm => orderVm.Description,
                    opt => opt.MapFrom(order => order.Description))
                .ForMember(orderVm => orderVm.CreateDate,
                    opt => opt.MapFrom(order => order.CreateDate))
                .ForMember(orderVm => orderVm.EditDate,
                    opt => opt.MapFrom(order => order.EditDate))
                .ForMember(orderVm => orderVm.Id,
                    opt => opt.MapFrom(order => order.Id));
        }
    }
}
