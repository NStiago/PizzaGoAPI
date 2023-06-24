namespace PizzaGoAPI.Services.MailServece
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}