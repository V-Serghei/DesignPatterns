using DesignPatterns.Memento.ex1;
using DesignPatterns.Memento.ex2;

namespace DesignPatterns.Client.Memento;

public class MementoClient
{
    public void Run()
    {
        // Create the text editor (originator)
        var editor = new TextEditor();

        // Create the history (caretaker)
        var history = new History();

        // Initial state
        history.Push(editor.Save());

        // Make some changes
        editor.Type("Hello, ");
        history.Push(editor.Save());

        editor.Type("world!");
        history.Push(editor.Save());

        editor.MoveCursor(7);
        history.Push(editor.Save());

        editor.Type("beautiful ");
        history.Push(editor.Save());

        // Undo to go back to previous states
        Console.WriteLine("Performing undo operation...");
        editor.Restore(history.Undo());

        Console.WriteLine("Performing undo operation again...");
        editor.Restore(history.Undo());

        // Redo to go forward again
        Console.WriteLine("Performing redo operation...");
        editor.Restore(history.Redo());

        // Make a new change (clears redo stack)
        editor.DeleteText(5);
        history.Push(editor.Save());

        // Try to redo (should not be possible)
        Console.WriteLine("Trying to redo after a new change...");
        editor.Restore(history.Redo());
        
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        DocumentR document = new DocumentR();
        DocumentHistory history1 = new DocumentHistory();

        // Начальное состояние
        document.Display();

        // Пользователь редактирует документ
        document.Edit("Привет, мир!");
        history1.SaveState(document.Save());

        document.Edit(" Это тест.");
        history1.SaveState(document.Save());

        document.Display();

        // Отмена последнего изменения
        DesignPatterns.Memento.ex2.Memento previousState = history1.GetPreviousState();
        if (previousState != null)
        {
            document.Restore(previousState);
        }

        document.Display();
    }
}