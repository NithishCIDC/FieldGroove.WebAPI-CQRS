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
    public class IsRegisteredQueryHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<IsRegisteredQuery, bool>
    {
        public async Task<bool> Handle(IsRegisteredQuery request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<LoginModel>(request);
            return await unitOfWork.UserRepository.IsValid(entity);
        }
    }
}
