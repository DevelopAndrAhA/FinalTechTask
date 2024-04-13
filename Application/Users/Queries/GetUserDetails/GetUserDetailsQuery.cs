using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }        
}
