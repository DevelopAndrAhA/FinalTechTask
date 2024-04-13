using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Description { get; set; }
    }
}
