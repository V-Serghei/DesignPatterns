namespace DesignPatterns.Mediator.ex1;

public class ContentEditorMediator:ContentEditorMediatorAbstract
{
    private object currentData;
    private Product currentProduct;
    private readonly List<string> validationErrors = new List<string>();

    public override void HandleEvent(string eventType, IEditorComponent sender, object data)
    {
        switch (eventType)
        {
            case "ContentUpdated":
                currentData = data;
                foreach (var component in components)
                {
                    if (component is PreviewPanel)
                        component.Notify("UpdatePreview", currentData);
                }
                break;
            case "SaveClicked":
                foreach (var component in components)
                {
                    if (component is ProductList)
                        component.Notify("AddProduct", currentData);
                    if (component is StatusBar)
                        component.Notify("ShowMessage", "Saved");
                }
                break;
            case "PublishClicked":
                foreach (var component in components)
                {
                    if (component is ProductList)
                        component.Notify("PublishProduct", currentData);
                    if (component is StatusBar)
                        component.Notify("ShowMessage", "Published");
                }
                break;
            case "CancelClicked":
                currentData = null;
                foreach (var component in components)
                {
                    if (component is EditForm)
                        component.Notify("ResetForm", null);
                    if (component is PreviewPanel)
                        component.Notify("ClearPreview", null);
                    if (component is StatusBar)
                        component.Notify("ShowMessage", "Cancelled");
                }
                break;
        }
    }
}