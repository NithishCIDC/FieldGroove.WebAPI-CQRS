using AutoMapper;
using FieldGroove.Application.CQRS.Accounts.IsRegistered;
using FieldGroove.Application.CQRS.Accounts.Register;
using FieldGroove.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.Mapper
{
    public class Mapper : Profile
    {
        public Mapper() 
        { 
            CreateMap<IsRegisteredQuery, LoginModel>();
            CreateMap<RegisterCommand, RegisterModel>();
        }
        
    }
}
