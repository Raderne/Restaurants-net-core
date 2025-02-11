namespace Domain.Configurations;

public class EmailOptions
{
    public string SmtpServer { get; set; }
    public int MailPort { get; set; }
    public bool UseSSL { get; set; } = true;
    public string Sender { get; set; }
    public string Password { get; set; }
}
