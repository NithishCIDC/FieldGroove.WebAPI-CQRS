using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Leads.GetAllLeads
{
    public class GetAllLeadsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllLeadsQuery, List<LeadsModel>>
    {
        public async Task<List<LeadsModel>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
           return await unitOfWork.LeadsRepository.GetAll();

        }
    }
}
