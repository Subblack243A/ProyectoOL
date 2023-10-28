using System;
using System.IO;
using System.Security.Cryptography;

public class EncryptUtility
{
    private string keySafe;
    private byte[] iv;

    public void SetKeySafe()
    {
        this.keySafe = Convert.ToBase64String(GenerateRandomKey()); ; 
    }

    public string GetKeySafe() { 
        return this.keySafe;
    }

    public void SetIv(byte[] iv) {
        this.iv = iv;
    }
    public string GetIv() { 
        return Convert.ToBase64String(this.iv); 
    }
    public string Encrypt(string plainText)
    {
        SetKeySafe();
        using (Aes aesAlg = Aes.Create())
        {
            string key = GetKeySafe();
            aesAlg.Key = Convert.FromBase64String(key);
            aesAlg.GenerateIV(); // Genera un IV aleatorio
            SetIv(aesAlg.IV);
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {   
                        swEncrypt.Write(plainText);
                    }
                }
                byte[] encryptedBytes = msEncrypt.ToArray();
                string encryptedText = Convert.ToBase64String(encryptedBytes);
                return encryptedText; // Devuelve texto cifrado
            }
        }
    }

    public static string Decrypt(string cipherText, string key, string iv)
    {
        byte[] ivBytes = Convert.FromBase64String(iv);
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Convert.FromBase64String(key);
            aesAlg.IV = ivBytes;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(cipherText);
                    }
                }
                byte[] encryptedBytes = msEncrypt.ToArray();
                string encryptedText = Convert.ToBase64String(encryptedBytes);
                return encryptedText; // Devuelve  texto cifrado
            }
        }
    }

    /*public static void Main(string[] args)
    {
        Console.Write("Ingrese el texto a cifrar: ");
        string originalText = Console.ReadLine();

        string key = Convert.ToBase64String(GenerateRandomKey());
        
        string encrypted = Encrypt(originalText, key);
        string decrypted = Decrypt(encrypted, key);

        Console.WriteLine("Texto Cifrado: " + encrypted);
        Console.WriteLine("Texto Descifrado: " + decrypted);
    }*/
    public static byte[] GenerateRandomKey()
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.GenerateKey();
            return aesAlg.Key;
        }
    }
}