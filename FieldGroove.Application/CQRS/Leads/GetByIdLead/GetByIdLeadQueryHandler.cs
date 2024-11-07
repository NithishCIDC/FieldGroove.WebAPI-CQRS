using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Leads.GetByIdLead
{
    public class GetByIdLeadQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetByIdLeadQuery, LeadsModel>
    {
        public async Task<LeadsModel> Handle(GetByIdLeadQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.LeadsRepository.GetById(request.Id);
        }
    }
}
