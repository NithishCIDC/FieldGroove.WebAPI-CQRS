﻿using System.ComponentModel.DataAnnotations;

namespace FieldGroove.Domain.Models
{
    public class RegisterModel
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
