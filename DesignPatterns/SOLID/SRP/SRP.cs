namespace DesignPatterns.SOLID.SRP;

public class SRP
{
    /// <summary>
    /// Плохой пример где класс EmailService нарушает принцип единственной ответственности (SRP).
    /// Решает много задач сразу 
    /// </summary>
    class EmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Logic to send email
        }
        public void SendEmailWithAttachment(string to, string subject, string body, string attachmentPath)
        {
            // Logic to send email with attachment
        }
        public void WriteEmail(string to, string subject, string body, string filePath)
        {
            // Logic to write email to file
        }
        public void ReadEmail(string filePath)
        {
            // Logic to read email from file
        }
    }

    /// <summary>
    /// Пример где мы разделяем обязанности на несколько классов, каждый из которых отвечает за свою задачу.
    ///Теперь каждый класс имеет единственную ответственность, что упрощает поддержку и тестирование.
    ///
    ///EmailSender отвечает только за отправку писем,
    /// EmailReader отвечает только за чтение писем из файлов,
    /// EmailWriter отвечает только за запись писем в файлы.
    /// </summary>
    class EmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Logic to send email
            // This method should not handle attachments or file operations
        }
        public void SendEmailWithAttachment(string to, string subject, string body, string attachmentPath)
        {
            // Logic to send email with attachment
            // This method should not handle file operations unrelated to sending emails
        }
    }
    
    class EmailReader
    {
        public void ReadEmail(string filePath)
        {
            // Logic to read email from file
            // This method should not handle sending emails or attachments
        }
    }
    class EmailWriter
    {
        public void WriteEmail(string to, string subject, string body, string filePath)
        {
            // Logic to write email to file
            // This method should not handle sending emails or reading emails
        }
    }
}