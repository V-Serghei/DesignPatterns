using DesignPatterns.Mediator.ex1;

namespace DesignPatterns.Client.Mediator;

public class MediatorClient
{
    public void Run()
    {
        // Создание посредника
        var mediator = new ContentEditorMediator();

        // Регистрация компонентов
        var editForm = new EditForm();
        var previewPanel = new PreviewPanel();
        var productList = new ProductList();
        var statusBar = new StatusBar();
        var toolbar = new Toolbar();

        mediator.RegisterComponent(editForm);
        mediator.RegisterComponent(previewPanel);
        mediator.RegisterComponent(productList);
        mediator.RegisterComponent(statusBar);
        mediator.RegisterComponent(toolbar);

        // Симуляция работы
        editForm.UpdateContent("Laptop - High-performance device");
        toolbar.Save();
        toolbar.Publish();
        toolbar.Cancel();
    }
}