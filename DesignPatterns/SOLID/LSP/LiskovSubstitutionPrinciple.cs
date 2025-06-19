namespace DesignPatterns.SOLID;

public class LiskovSubstitutionPrinciple
{
    // Принцип подстановки Лисков
    // Должна быть возможность вместо базового типа подставить любой его подтип.
    // Пример плохого использования:
    
    public class UIElement
    {
        public void SetPosition(int x, int y)
        {
            // Установка позиции элемента
        }
        public void SetColor(string color)
        {
            // Установка цвета элемента
        }
        public virtual string SetText(string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text), "Text cannot be null");
            } 
            if (text.Length > 50)
            {
                throw new ArgumentException("Text cannot be longer than 100 characters", nameof(text));
            }
            return text;
        }
        
        
    }
    
    public class Button : UIElement
    {
        public override string SetText(string text)
        {
            
            
            return base.SetText(text);
        }
        public void SetChild(UIElement child)
        {
            throw new InvalidOperationException("Button cannot have child elements");
        }
        
        
    }
    
}