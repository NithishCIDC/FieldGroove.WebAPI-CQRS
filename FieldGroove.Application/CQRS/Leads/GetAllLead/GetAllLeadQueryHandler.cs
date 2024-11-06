using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Leads.CreateLead
{
    public class GetAllLeadQueryHandler : IRequestHandler<GetAllLeadQuery, IEnumerable<LeadsModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllLeadQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            
        }
        public async Task<IEnumerable<LeadsModel>> Handle(GetAllLeadQuery request, CancellationToken cancellationToken)
        {
            var response = await unitOfWork.LeadsRepository.GetAll();

            return response;
        }
    }
}
