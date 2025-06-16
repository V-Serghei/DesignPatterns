using DesignPatterns.State.ex1;

namespace DesignPatterns.Client.StateClient;

public class StateClients
{
    public void Run()
    {
        // Create a new document in Draft state
        DocumentContext document = new DocumentContext("Annual Report");
        document.DisplayInfo();

        // Edit the document in Draft state
        document.Edit("Initial content for the annual report.");
        document.DisplayInfo();

        // Send for review - transitions to Moderation state
        document.Review();
        document.DisplayInfo();

        // Try to edit while in Moderation state
        document.Edit("Trying to change content during review");
        document.DisplayInfo();

        // Approve and publish - transitions to Published state
        document.Publish();
        document.DisplayInfo();

        // Archive the document - transitions to Archived state
        document.Archive();
        document.DisplayInfo();

        // Try to publish an archived document
        document.Publish();
        document.DisplayInfo();

        // Create a new document to demonstrate different flows
        DocumentContext article = new DocumentContext("News Article");
        article.Edit("Breaking news content");
        article.Review();
            
        // Try to archive from moderation
        article.Archive();
            
        // Publish and verify state change
        article.Publish();
        article.DisplayInfo();
            
        // Edit published document (creates new draft)
        article.Edit("Updated breaking news");
        article.DisplayInfo();
    }
}