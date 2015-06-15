using Mvc.Mailer;
using Gms.Web.Mvc.Mailers.Models;

namespace Gms.Web.Mvc.Mailers
{ 
    public interface IPasswordResetMailer
    {
			MvcMailMessage PasswordReset(MailerModel model);
	}
}