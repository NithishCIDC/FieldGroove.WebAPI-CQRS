using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Leads.DeleteLead
{
    public class DeleteLeadCommand(int id) : IRequest<bool>
    {
        public int Id { get; set; } = id;
    }

}
