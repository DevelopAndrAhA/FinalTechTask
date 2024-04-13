﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {    
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
