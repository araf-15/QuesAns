using QuesAns.Services.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace QuesAns.Models.AccountModels
{
    public class UserEmailOptionsModel
    {
        private readonly IEmailService _emailService;
        private const string TESTEMAILTEMPLETEPATH = @"Templetes/EmailTempletes/{0}.html";
        private const string CONFIRMATIONEMAILTEMPLETEPATH = @"Templetes/ConfirmationEmailTemplete/{0}.html";

        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<KeyValuePair<string, string>> PlaceHolders { get; set; }


        public UserEmailOptionsModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendConfirmEmailAsync(UserEmailOptionsModel model)
        {
            model.Body = UpdatePlaceHolders(GetEmailConfirmationBody("EmailConfirmation"), PlaceHolders);
            await _emailService.SendConfirmEmail(model);
        }

        private string GetEmailConfirmationBody(string templeteName)
        {
            var body = File.ReadAllText((string.Format(CONFIRMATIONEMAILTEMPLETEPATH, templeteName)));
            return body;
        }

        private string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach (var placeholder in keyValuePairs)
                {
                    if (text.Contains(placeholder.Key))
                    {
                        text = text.Replace(placeholder.Key, placeholder.Value);
                    }
                }
            }

            return text;
        }

    }
}
