using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Cezar
{
    public static class StringExtension
    {
        public static string EncryptCezar(this string str, int key)
        {
            string inputMessage = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (((int)str[i] >= (int)'A' && (int)str[i] <= (int)'Z') || ((int)str[i] >= (int)'a' && (int)str[i] <= (int)'z'))
                {
                    if (((int)str[i] + key > (int)'Z' && (int)str[i] < (int)'a') || (int)str[i] + key > (int)'z')
                    {
                        inputMessage += (char)((int)str[i] + key - 26);
                    }
                    else
                    {
                        inputMessage += (char)(str[i] + key);
                    }
                }
                else
                if (((int)str[i] >= (int)'А' && (int)str[i] <= (int)'Я') || ((int)str[i] >= (int)'а' && (int)str[i] <= (int)'я'))
                {
                    if (((int)str[i] + key > (int)'Я' && (int)str[i] < (int)'а') || (int)str[i] + key > (int)'я')
                    {
                        inputMessage += (char)((int)str[i] + key - 33);
                    }
                    else
                    {
                        inputMessage += (char)(str[i] + key);
                    }
                }
                else
                    inputMessage += str[i];
            }
            str = inputMessage;
            return str;
        }
        public static string DecipherCezar(this string str, int key)
        {
            string inputMessage = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (((int)str[i] >= (int)'A' && (int)str[i] <= (int)'Z') || ((int)str[i] >= (int)'a' && (int)str[i] <= (int)'z'))
                {
                    if ((int)str[i] - key < (int)'A' || ((int)str[i] > (int)'Z') && (int)str[i] - key < (int)'a')
                    {
                        inputMessage += (char)((int)str[i] - key + 26);
                    }
                    else
                    {
                        inputMessage += (char)(str[i] - key);
                    }
                }
                else
                if (((int)str[i] >= (int)'А' && (int)str[i] <= (int)'Я') || ((int)str[i] >= (int)'а' && (int)str[i] <= (int)'я'))
                {
                    if ((int)str[i] - key < (int)'А' || ((int)str[i] > (int)'Я') && (int)str[i] - key < (int)'а')
                    {
                        inputMessage += (char)((int)str[i] - key + 33);
                    }
                    else
                    {
                        inputMessage += (char)(str[i] - key);
                    }
                }
                else
                    inputMessage += str[i];
            }
            str = inputMessage;
            return str;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("Enter text: ");
            string message = Console.ReadLine();
            Console.Write("Enter key: ");
            int secretKey = Convert.ToInt32(Console.ReadLine());           
            Console.WriteLine($"Encrypted message: {message.EncryptCezar(secretKey)}");            
            Console.WriteLine($"Decrypted message: {(message.EncryptCezar(secretKey)).DecipherCezar(secretKey)}");
            Console.ReadLine();
        }
    }
}
