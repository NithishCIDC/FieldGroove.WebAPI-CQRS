using FieldGroove.Infrastructure.Data;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Application.JwtAuthtoken;

namespace FieldGroove.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext dbContext,IGenerateJwtToken generateJwtToken) : IUnitOfWork
    {
        public IUserRepository UserRepository { get; private set; } = new UserRepository(dbContext, generateJwtToken);

        public ILeadsRepository LeadsRepository { get; private set; } = new LeadsRepository(dbContext);
    }
}
