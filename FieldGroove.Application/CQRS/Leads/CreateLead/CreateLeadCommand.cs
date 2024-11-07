using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Leads.CreateLead
{
    public class CreateLeadCommand :IRequest<bool>
    {
        [Required]
        public string? ProjectName { get; set; }

        public string? Status { get; set; }

        public bool Type { get; set; }

        public long Contact { get; set; }

        public string? Action { get; set; }

        public string? Assignee { get; set; }

        public DateTime? BidDate { get; set; }
    }
}
