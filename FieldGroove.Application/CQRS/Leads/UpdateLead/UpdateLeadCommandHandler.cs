using AutoMapper;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Leads.UpdateLead
{
    public class UpdateLeadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateLeadCommand, bool>
    {
        public async Task<bool> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<LeadsModel>(request);
            return await unitOfWork.LeadsRepository.Update(model);
        }
    }
}
