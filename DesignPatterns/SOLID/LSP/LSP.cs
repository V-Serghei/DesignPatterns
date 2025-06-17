namespace DesignPatterns.SOLID;

public class LSP
{
    class OpenMedia
    {
        public virtual void Play()
        {
            // Default implementation for playing media
            Console.WriteLine("Playing media...");
        }
        
        public virtual void Pause()
        {
            // Default implementation for pausing media
            Console.WriteLine("Pausing media...");
        }
        
        public virtual void SetQuality(int qualityX, int qualityY)
        {
            // Default implementation for setting media quality
            Console.WriteLine($"Setting media quality to {qualityX}x{qualityY}");
        }
        
    }
    
    
    class VideoPlayer : OpenMedia
    {
        public override void Play()
        {
            // Specific implementation for playing video
            Console.WriteLine("Playing video...");
        }
        
        public override void Pause()
        {
            // Specific implementation for pausing video
            Console.WriteLine("Pausing video...");
        }
        public override void SetQuality(int qualityX, int qualityY)
        {
            // Specific implementation for setting video quality
            Console.WriteLine($"Setting video quality to {qualityX}x{qualityY}");
        }
        
    }
    
    class MusicPlayer : OpenMedia
    {
        public override void Play()
        {
            // Specific implementation for playing music
            Console.WriteLine("Playing music...");
        }
        
        public override void Pause()
        {
            // Specific implementation for pausing music
            Console.WriteLine("Pausing music...");
        }

        public override void SetQuality(int qualityX, int qualityY)
        {
            throw new NotSupportedException("Music player does not support quality settings.");
        }
    }
    
    class ImageViewer : OpenMedia
    {
        public override void Play()
        {
            // Specific implementation for displaying an image
            Console.WriteLine("Displaying image...");
        }
        
        public override void Pause()
        {
            // Specific implementation for pausing image display
        }

        public override void SetQuality(int qualityX, int qualityY)
        {
            // Specific implementation for setting image quality
            Console.WriteLine($"Setting image quality to {qualityX}x{qualityY}");
        }
    }




    interface IOpenMediaPlay
    {
        void Open();
        void SetConfig(int parameter);
    }
    interface IOpenMediaPause
    {
        void Pause();
    }

    class ImageOpen : IOpenMediaPlay
    {
        public void Open()
        {
            Console.WriteLine("Opening image...");
        }

        public void SetConfig(int parameter)
        {
            switch (parameter)
            {
                case 1:
                    Console.WriteLine("Setting image quality to low.");
                    break;
                case 2:
                    Console.WriteLine("Setting image quality to medium.");
                    break;
                case 3:
                    Console.WriteLine("Setting image quality to high.");
                    break;
                default:
                    Console.WriteLine("Invalid image quality setting.");
                    break;
            }
        }
        
    }
    class VideoOpen : IOpenMediaPlay, IOpenMediaPause
    {
        public void Open()
        {
            Console.WriteLine("Play video...");
        }

        public void SetConfig(int parameter)
        {
            switch (parameter)
            {
                case 1:
                    Console.WriteLine("Setting video quality to low.");
                    break;
                case 2:
                    Console.WriteLine("Setting video quality to medium.");
                    break;
                case 3:
                    Console.WriteLine("Setting video quality to high.");
                    break;
                default:
                    Console.WriteLine("Invalid video quality setting.");
                    break;
            }
        }

        public void Pause()
        {
            Console.WriteLine("Pausing video...");
        }
    }
    
    class MusicOpen : IOpenMediaPlay, IOpenMediaPause
    {
        public void Open()
        {
            Console.WriteLine("Play music...");
        }

        public void SetConfig(int parameter)
        {
            var settingsVolume = parameter;
        }

        public void Pause()
        {
            Console.WriteLine("Pausing music...");
        }
    }
    

   
}