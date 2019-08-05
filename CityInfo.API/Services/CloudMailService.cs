using static System.Diagnostics.Debug;


namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _maitTo = Startup.Configuration["mailSettings:mailToAddress"];
        private string _mailFrom = Startup.Configuration["mailSettings:mailFromAddress"];

        public void Send(string subject, string message)
        {
            //send mail - output to debug window
            WriteLine($"Mail from {_mailFrom} to {_maitTo} with CloudMailService.");
            WriteLine($"Subject: {subject}");
            WriteLine($"Message: {message}");
        }

    }
}
