using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
