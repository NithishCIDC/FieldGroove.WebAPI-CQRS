using AutoMapper;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Accounts.IsValid
{
    public class IsValidQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<IsValidQuery, bool>
    {
        public async Task<bool> Handle(IsValidQuery request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<LoginModel>(request);
            return await unitOfWork.UserRepository.IsValid(entity);
        }
    }
}
