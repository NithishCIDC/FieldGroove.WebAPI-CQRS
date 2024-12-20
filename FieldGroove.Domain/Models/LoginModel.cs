﻿using System.ComponentModel.DataAnnotations;

namespace FieldGroove.Domain.Models
{
    public class LoginModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public bool RemenberMe { get; set; }
    }
}
