namespace DesignPatterns.SOLID.DIP;

public class DependencyInversionPrinciple
{
    /// <summary>
    /// Принцип инверсии зависимостей
    /// Dependency Inversion Priciple
    /// Модули верхнего уровня не должны зависиеть от  модулей нижнего уровня. Они оба должны зависеть от абстракций.
    /// Абстракция не должна зависесть от делателй. Датали должны зависесть от обстракций.
    /// </summary>
    /// Плохой пример:

    public class DrawPencil
    {
        public void Draw(string carcase)
        {
            Console.WriteLine("Drawing with pencil");
        }
    }
    
    public class DrawColorPencil
    {
        public void Draw(string carcase)
        {
            Console.WriteLine("Drawing with color pencil");
        }
    }

    public class Picture
    {
        private string _carcass;
        
        public Picture(string carcass)
        {
            _carcass = carcass;
        }
        
        public void DrawPicture()
        {
            var pencil = new DrawPencil();
            pencil.Draw(_carcass);
            Console.WriteLine($"Drawing picture with carcass: {_carcass}");
        }
    }


    /// Хороший пример:
    public interface IDrawable
    {
        void Draw(string carcass);
    }
    
    public class DrawNonColor:IDrawable
    {
        public void Draw(string carcass)
        {
            Console.WriteLine("Drawing with non color pencil");
        }
    }
    
    public class DrawColor:IDrawable
    {
        public void Draw(string carcass)
        {
            Console.WriteLine("Drawing with color pencil");
        }
    }

    public class PictureUpgrade
    {
        private string _carcass;
        private IDrawable _drawable;


        public PictureUpgrade(string carcass, IDrawable drawable)
        {
            _carcass = carcass;
            _drawable = drawable;
        }
        
        public void DrawPicture()
        {
            _drawable.Draw(_carcass);
            Console.WriteLine($"Drawing picture with carcass: {_carcass}");
        }
    }
    
    
}