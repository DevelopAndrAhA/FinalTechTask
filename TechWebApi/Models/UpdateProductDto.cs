using Application.Common.Mapping;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using AutoMapper;

namespace TechWebApi.Models
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(prodCommand => prodCommand.Name,
                    opt => opt.MapFrom(prodDto => prodDto.Name))
                .ForMember(prodCommand => prodCommand.Description,
                    opt => opt.MapFrom(prodDto => prodDto.Description))
                .ForMember(prodCommand => prodCommand.Price,
                    opt => opt.MapFrom(prodDto => prodDto.Price));
        }

    }
}
