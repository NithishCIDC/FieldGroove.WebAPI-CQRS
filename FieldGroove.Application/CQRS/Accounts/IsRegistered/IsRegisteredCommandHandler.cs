using AutoMapper;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Accounts.IsRegistered
{
    public class IsRegisteredCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<IsRegisteredCommand, bool>
    {
        public async Task<bool> Handle(IsRegisteredCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<LoginModel>(request);
            return await unitOfWork.UserRepository.IsRegistered(entity);
        }
    }
}
