namespace PizzaGoAPI.Services.MailServece
{
    public class LocalMailService : IMailService
    {
        private readonly string MailTo = string.Empty;
        private readonly string MailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            MailTo = configuration["mailSettings:mailToAddress"];
            MailFrom = configuration["mailSettings:mailFromAddress"];
        }
        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {MailFrom} to {MailTo}, " +
                $"with {nameof(LocalMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
