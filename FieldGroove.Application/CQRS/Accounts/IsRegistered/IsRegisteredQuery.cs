﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Accounts.IsRegistered
{
    public class IsRegisteredQuery:IRequest<bool>
    {
        public string Email {  get; set; }=string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}