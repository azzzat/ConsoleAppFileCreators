using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleAppFileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"..\..\..\..\Files\1000items.txt";
            StringBuilder finalStringBuilder = new StringBuilder();
            Random rnd = new Random();

            for (int i = 1; i <= 1000; i++)
            {
                String article;
                if (i < 100)
                {
                    article = "Кросовки";
                }
                else if (i < 300)
                {
                    article = "Футболка";
                }
                else if (i < 700)
                {
                    article = "Спортивка";
                }
                else
                {
                    article = "Шапка";
                }

                int price = rnd.Next(1, 1000);

                finalStringBuilder.Append(i);
                finalStringBuilder.Append("\t");
                finalStringBuilder.Append(article);
                finalStringBuilder.Append("\t");
                finalStringBuilder.Append(price);
                finalStringBuilder.Append("\n");
            }

            
            try 
            {
                File.WriteAllText(path, finalStringBuilder.ToString());
            } 
            catch
            {
                Console.WriteLine("Возникло исключение при записи файла");
            }

            Console.WriteLine(Directory.GetCurrentDirectory());

            Console.ReadLine();
        }
    }
}
