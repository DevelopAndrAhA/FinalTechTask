using Application.Common.Mapping;
using Application.Products.Commands.CreateProduct;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TechWebApi.Models
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(prodCommand => prodCommand.Name,
                    opt => opt.MapFrom(prodDto => prodDto.Name))
                .ForMember(prodCommand => prodCommand.Description,
                    opt => opt.MapFrom(prodDto => prodDto.Description))
                .ForMember(prodCommand => prodCommand.Price,
                    opt => opt.MapFrom(prodDto => prodDto.Price));
        }
    }
}
