using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public IList<Product> Products { get; set; }
    }
}
