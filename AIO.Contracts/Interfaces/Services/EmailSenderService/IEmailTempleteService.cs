namespace AIO.Contracts.IServices.Services.EmailSenderService
{
    public interface IEmailTempleteService
    {
        Task SendEmailOfCompleteMigration(string title, List<string> to);
        Task SendEmailOfUnCompleteMigration(string title, string sheet, int row, int col, List<string> to);
        Task SendUserPasswordMail(string name, string userName, string password, string email, string url = "");
    }
}
