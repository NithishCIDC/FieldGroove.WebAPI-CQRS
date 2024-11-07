using FieldGroove.Domain.Interfaces;
using FieldGroove.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldGroove.Application.JwtAuthtoken;
using System.Dynamic;
using AutoMapper;

namespace FieldGroove.Application.CQRS.Accounts.Login
{
    public class LoginQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<LoginQuery, object>
    {
        public async Task<object> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = mapper.Map<LoginModel>(request);

            var isUser = await unitOfWork.UserRepository.IsRegistered(response);
            return isUser;
        }
    }
}
