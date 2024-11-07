using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Application.CQRS.Accounts.Register
{
    public class RegisterCommand : IRequest<bool>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string CompanyName { get; set; }
        public long Phone { get; set; }
        [Key]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PasswordAgain { get; set; }
        public required string TimeZone { get; set; }
        public required string StreetAddress1 { get; set; }
        public required string StreetAddress2 { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Zip { get; set; }
    }
}
