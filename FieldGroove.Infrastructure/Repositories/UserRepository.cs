using FieldGroove.Infrastructure.Data;
using FieldGroove.Domain.Models;
using Microsoft.EntityFrameworkCore;
using FieldGroove.Domain.Interfaces;
using Azure.Core;
using System.Dynamic;
using FieldGroove.Application.JwtAuthtoken;

namespace FieldGroove.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext dbContext,IGenerateJwtToken GenerateToken) : IUserRepository
    {
        public async Task<bool> Create(RegisterModel entity)
        {
            try
            {
                await dbContext.UserData.AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<object> IsRegistered(LoginModel entity)
        {
            bool isUser = await dbContext.UserData.AnyAsync(x => x.Email == entity.Email!);
            if (isUser)
            {
                if (await dbContext.UserData.AnyAsync(x => x.Password == entity.Password!))
                {
                    var token = new
                    {
                        User = entity.Email,
                        Token = GenerateToken.JwtToken(entity.Email!),
                        Status = "OK",
                        Timestamp = DateTime.Now
                    };
                    return token;
                }
                return new { error = "Invalid Credential" };
            }
            return new { error="Invalid User"};
        }

        public async Task<bool> IsValid(LoginModel entity)
        {
            return await dbContext.UserData.AnyAsync(x => x.Email == entity.Email!);
        }
    }
}
