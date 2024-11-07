using AutoMapper;
using FieldGroove.Application.CQRS.Leads.CreateLead;
using FieldGroove.Application.Mapper;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Leads.DeleteLead
{
    public class DeleteLeadCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteLeadCommand,bool>
    {
        public async Task<bool> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            var model = await unitOfWork.LeadsRepository.GetById(request.Id);
            return await unitOfWork.LeadsRepository.Delete(model);
        }
    }
}
