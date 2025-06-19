namespace DesignPatterns.SOLID.ISP;

public class InterfaceSegregationPrinciple
{
    /// <summary>
    /// Принцип разделения интерфейсов
    /// Клиент не должен вынужденно зависеть от интерфейсов, которыми он не пользуется.
    /// </summary>
    /// Плохой пример:
    public interface ISenderService
    {
        void SendEmail(string to, string subject, string body);
        void ReceiveEmail();
        void DeleteEmail(int emailId);
        void ArchiveEmail(int emailId);
        void MarkEmailAsRead(int emailId);
        void DeleteAllEmails();
    }
    public class EmailService : ISenderService
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Реализация отправки email
        }

        public void ReceiveEmail()
        {
            // Реализация получения email
        }

        public void DeleteEmail(int emailId)
        {
            // Реализация удаления email
        }

        public void ArchiveEmail(int emailId)
        {
            // Реализация архивирования email
        }

        public void MarkEmailAsRead(int emailId)
        {
            // Реализация пометки email как прочитанного
        }

        public void DeleteAllEmails()
        {
            // Реализация удаления всех email
        }
    }
    
    public class SmsService : ISenderService
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Реализация отправки SMS
        }

        public void ReceiveEmail()
        {
            // Реализация получения SMS
        }

        public void DeleteEmail(int emailId)
        {
            // Реализация удаления SMS
        }

        public void ArchiveEmail(int emailId)
        {
            // Нет реализация архивирования SMS
        }

        public void MarkEmailAsRead(int emailId)
        {
            // Реализация пометки SMS как прочитанного
        }

        public void DeleteAllEmails()
        {
            // Реализация удаления всех SMS
        }
    }
    public interface ISenderEService
    {
        void SendEmail(string to, string subject, string body);
        void ReceiveEmail();
        
    }
    public interface ISenderArchiveService
    {
        void ArchiveEmail(int emailId);
        void MarkEmailAsRead(int emailId);
    }
    public interface ISenderDeletedService
    {
        void DeleteEmail(int emailId);
        void DeleteAllEmails();
    }
    
    
    public class EmailEService : ISenderEService
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Реализация отправки email
        }

        public void ReceiveEmail()
        {
            // Реализация получения email
        }
    }
    public class EmailServiceUpgrade : ISenderDeletedService, ISenderArchiveService, ISenderEService
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Реализация отправки email
        }

        public void ReceiveEmail()
        {
            // Реализация получения email
        }

        public void ArchiveEmail(int emailId)
        {
            // Реализация архивирования email
        }

        public void MarkEmailAsRead(int emailId)
        {
            // Реализация пометки email как прочитанного
        }

        public void DeleteEmail(int emailId)
        {
            // Реализация удаления email
        }

        public void DeleteAllEmails()
        {
            // Реализация удаления всех email
        }
    }
   
    
    
    
}