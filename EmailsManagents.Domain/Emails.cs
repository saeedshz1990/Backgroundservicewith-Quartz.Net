namespace EmailsManagents.Domain
{
    public class Emails
    {
        public long Id { get; private set; }
        public string Email { get; private set; }

        public Emails(string email)
        {
            Email = email;
        }
    }
}
