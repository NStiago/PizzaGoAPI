﻿namespace PizzaGoAPI.Services.MailServece
{
    public class CloudMailService : IMailService
    {
        private readonly string MailTo = string.Empty;
        private readonly string MailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            MailTo = configuration["mailSettings:mailToAddress"];
            MailFrom = configuration["mailSettings:mailFromAddress"];
        }
        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {MailFrom} to {MailTo}, " +
                $"with {nameof(CloudMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
