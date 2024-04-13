using Application.Common.Mapping;
using Application.Orders.Queries.GetOrder;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(prod => prod.Id,
                    opt => opt.MapFrom(prod => prod.Id))
                .ForMember(prod => prod.Name,
                    opt => opt.MapFrom(prod => prod.Name))
                .ForMember(prod => prod.Price,
                    opt => opt.MapFrom(prod => prod.Price))
                ;
        }
    }
}