namespace PizzaGoAPI.Services.MailServece
{
    public class LocalMailService : IMailService
    {
        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {MailFrom} to {MailTo}, " +
                $"with {nameof(LocalMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
