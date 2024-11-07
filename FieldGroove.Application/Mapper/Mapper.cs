using AutoMapper;
using FieldGroove.Application.CQRS.Accounts.IsValid;
using FieldGroove.Application.CQRS.Accounts.Login;
using FieldGroove.Application.CQRS.Accounts.Register;
using FieldGroove.Application.CQRS.Leads.CreateLead;
using FieldGroove.Application.CQRS.Leads.UpdateLead;
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
            //AccountController
            CreateMap<IsValidQuery, LoginModel>();
            CreateMap<RegisterCommand, RegisterModel>();
            CreateMap<IsValidQuery,LoginModel>();
            CreateMap<LoginQuery, LoginModel>();
            //LeadController
            CreateMap<CreateLeadCommand,LeadsModel>();
            CreateMap<UpdateLeadCommand, LeadsModel>();
        }
        
    }
}
