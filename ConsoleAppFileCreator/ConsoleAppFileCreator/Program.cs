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
            //указываю расположение папки и файла в котором будут 1000 строк товаров
            String path = @"..\..\..\..\Files\1000items.txt";

            //весь сгенерированный список будет хранится в одной строке
            StringBuilder finalStringBuilder = new StringBuilder();

            //генератор случайных чисел для указания стоимости продукта
            Random rnd = new Random();

            
            for (int i = 1; i <= 1000; i++)
            {

                //Название продукта будет генерироваться в зависимости от позиции в списке
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
                    article = "Шапка-ушанка";
                }

                //генерирование стоимости продукта - от 1 до 1000
                int price = rnd.Next(1, 1000);

                //запись сгенерированной строки в финальную строку с табуляцией между столбцами
                finalStringBuilder.Append(i);
                finalStringBuilder.Append("\t");
                finalStringBuilder.Append(article);
                finalStringBuilder.Append("\t");
                finalStringBuilder.Append(price);
                finalStringBuilder.Append("\n");
            }

            
            try 
            {
                //финальная строка которая уже имеет большой размер и содержит все строки
                //единожды отправляется в указаный изначально путь
                //если запустить повторно то файл перезапишется с другими величинами стоимости продуктов
                File.WriteAllText(path, finalStringBuilder.ToString());
            } 
            catch
            {
                Console.WriteLine("Возникло исключение при записи файла");
            }
        }
    }
}
