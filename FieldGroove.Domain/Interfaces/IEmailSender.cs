using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGroove.Domain.Interfaces
{
    public interface IEmailSender
    {
       void EmailSendAsync(string email, string subject, string message);
    }
}
