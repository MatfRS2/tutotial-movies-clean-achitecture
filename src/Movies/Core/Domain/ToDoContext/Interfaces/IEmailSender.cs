using System.Threading.Tasks;

namespace Movies.Domain.ToDoContext.Interfaces;

public interface IEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string body);
}
