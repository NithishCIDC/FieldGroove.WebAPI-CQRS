using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Domain.Models
{
    public class JwtModel
    {
        public static string Key {  get; set; }
        public static string Issuer = "yourIssuer";
        public static string Audience = "yourAudience";

    }
}
