using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //расположение папки и файла в котором 1000 строк с наименованием товаров, стоимости и нумерации
            string path = @"..\..\..\..\Files\1000items.txt";

            StreamReader sr = null;
            try
            {
                sr = new StreamReader(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Возникло исключение при чтении файла. Файла нет");
                Console.ReadKey();
            }

            // Два сортированных списка
            // rowItemList - для хранения списка "номер строки - Название"
            // rowPriceList - для хранения списка "номер строки - Стоимость"
            SortedList<Int32, String> rowItemList = new SortedList<int, string>();
            SortedList<Int32, Int32> rowPriceList = new SortedList<int, int>();


            // заполняем сортированные списки данными полученными из файла с 1000 строками
            while (!sr.EndOfStream)
            {
                //из каждой строки получаем массив из 3 значений - номер строки, наименование, стоимость 
                String[] row = sr.ReadLine().Split('\t');
                
                //выводим из массива значения
                int firsLineOfRow = Int32.Parse(row[0]);
                String secondLineOfRow = row[1];
                int thirdLineOfRow = Int32.Parse(row[2]);

                //добавляем значения в сортированные списки
                rowItemList.Add(firsLineOfRow, secondLineOfRow);
                rowPriceList.Add(firsLineOfRow, thirdLineOfRow);
            }
            //закрываем доступ к файлу
            sr.Close();

            //значение j - это стоимость продукции, 100 - диапазон цен в каждом создаваемом файле 
            for (int j = 0; j < 1000; j = j + 100)
            {
                //данные для записи в новый файл собираются в StringBuilder
                StringBuilder finalStringBuilder = new StringBuilder();

                //расположение нового файла и генерация названия в зависимости от ценового диапозона
                path = @"..\..\..\..\Files\items_from_" + (j +1) 
                    + "_to_" + (j+100) + ".txt";

                //проверка значения цены в сортированом списке на соответствие ценовому диапозону
                for (int i = 1; i <= 1000; i++)
                {
                    int price = rowPriceList[i];
                    if (price > j && price < j + 100)
                    {
                        finalStringBuilder.Append(i);
                        finalStringBuilder.Append("\t");
                        finalStringBuilder.Append(rowItemList[i]);
                        finalStringBuilder.Append("\t");
                        finalStringBuilder.Append(price);
                        finalStringBuilder.Append("\n");
                    }
                }

                try
                {
                    //отправка готового текста в файл
                    File.WriteAllText(path, finalStringBuilder.ToString());
                }
                catch
                {
                    Console.WriteLine("Возникло исключение при записи файла");
                    Console.ReadKey();
                }
            }

            //Console.ReadKey();
        }
    }
}
