using System.Threading.Tasks;

namespace Movies.Domain.PripremaContext.Services;

public interface IEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string body);
}
