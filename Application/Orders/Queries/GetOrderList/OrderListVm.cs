using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrder
{
    public class OrderListVm
    {
        public IList<Order> Orders { get; set; }
    }
}
