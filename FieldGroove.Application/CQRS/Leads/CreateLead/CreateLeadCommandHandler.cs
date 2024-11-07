using AutoMapper;
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
    public class CreateLeadCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<CreateLeadCommand, bool>
    {
        public async Task<bool> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<LeadsModel>(request);
            return await unitOfWork.LeadsRepository.Create(model);
        }
    }
}
