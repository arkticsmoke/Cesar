using System;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Cesar
{
    public class Cesar
    {
        // Русский алфавит
        const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        private string CodeEncode(string text, int k)
        {
            //Добавляем маленькие буквы
            var allAlfabet = alfabet + alfabet.ToLower();
            var t = allAlfabet.Length;
            var l = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = allAlfabet.IndexOf(c);
                if (index < 0)
                {
                    //если такого символа нет то оставляем его
                    l += c.ToString();
                }
                else
                {
                    var codeIndex = (t + index + k) % t;
                    l += allAlfabet[codeIndex];
                }
            }
            return l;
         }
        //шифруем текст
        public string Encrypt(string plainMsg, int key) => CodeEncode(plainMsg, key);

        //дешифруем текст
        public string Decrypt(string encryptMsg, int key) => CodeEncode(encryptMsg, -key);


    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var cipher = new Cesar();
                Console.WriteLine("Зашифровать - 1, Расшифровать - 2, для выхода - 0");
                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Введите слово");
                    var msg = Console.ReadLine();
                    Console.WriteLine("введите сдвиг");
                    var key = Convert.ToInt32(Console.ReadLine());
                    var enText = cipher.Encrypt(msg, key);
                    Console.WriteLine("Зашифрованное сообщение {0}", enText);
                    Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Введите слово");
                    var msg = Console.ReadLine();
                    Console.WriteLine("введите сдвиг");
                    var key = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Расшифрованное сообщение {0}", cipher.Decrypt(msg, key));
                    Console.ReadLine();
                }
                else if (choice == 0)
                {
                    break;
                }
            }
        }
    }
}
