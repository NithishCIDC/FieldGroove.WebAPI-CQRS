using FieldGroove.Domain.Models;

namespace FieldGroove.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Create(RegisterModel entity);
        Task<object> IsRegistered(LoginModel enitity);
        Task<bool> IsValid(LoginModel enitity);
    }
}
