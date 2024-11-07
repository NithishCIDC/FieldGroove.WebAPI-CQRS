using AutoMapper;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Accounts.Register
{
    public class RegisterCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<RegisterCommand, bool>
    {
        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<RegisterModel>(request);
            return await unitOfWork.UserRepository.Create(entity);
        }
    }
}
