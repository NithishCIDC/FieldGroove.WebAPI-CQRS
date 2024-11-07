using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Leads.CreateLead
{
    public class CreateLeadCommand :IRequest<LeadsModel>
    {

    }
}
