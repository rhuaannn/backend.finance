namespace backend.finance.domain.ValueObjects
{
    public class Email
    {
        public string EmailAddress { get; private set; } = string.Empty;

        public Email()
        {
            
        }
        public Email(string value)
        {
            EmailAddress = value;
            if (!IsValid())
            {
               throw new ArgumentException("Invalid email address format.", nameof(value));
            }


        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(EmailAddress))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(EmailAddress);
                return addr.Address == EmailAddress;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return EmailAddress;
        }

        public static implicit operator string(Email email)
        {
            return email.EmailAddress;
        }
    }
}
