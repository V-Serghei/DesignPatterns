using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

namespace DesignPatterns.SOLID.OCP;

public class Open_ClosedPrinciple
{
    // Принцип открытости/закрытости
    // Сущности программы должны быть открыты для расширения, но закрыты для изменения.
    
    // public class EncyptionService
    // {
    //     public string Encrypt(string data)
    //     {
    //         var encryption = data switch;
    //         {
    //             "AES" => EncryptWithAES(data),
    //             "RSA" => EncryptWithRSA(data),
    //             "DES"  => EncryptWithDES(data), 
    //             _ => throw new NotSupportedException("Unsupported encryption type")
    //         };
    //         return encryption;
    //     }
    // }
    
    
    public interface IStrategy
    {
        string Encrypt(string data);
    }
    
    public class AESEncryption : IStrategy
    {
        public string Encrypt(string data)
        {
            // Реализация шифрования AES
            return $"AES Encrypted: {data}";
        }
    }
    public class RSAEncryption : IStrategy
    {
        public string Encrypt(string data)
        {
            // Реализация шифрования RSA
            return $"RSA Encrypted: {data}";
        }
    }
    public class DESEncryption : IStrategy
    {
        public string Encrypt(string data)
        {
            // Реализация шифрования DES
            return $"DES Encrypted: {data}";
        }
    }
    public class BlowfishEncryption : IStrategy
    {
        public string Encrypt(string data)
        {
            // Реализация шифрования Blowfish
            return $"Blowfish Encrypted: {data}";
        }
    }
    
    
    public class ContextEncryption
    {
        private readonly IStrategy _strategy;

        public ContextEncryption(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public string Encrypt(string data)
        {
            return _strategy.Encrypt(data);
        }
        
    }
    
}