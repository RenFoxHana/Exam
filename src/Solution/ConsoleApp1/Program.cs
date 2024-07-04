using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Applications applications = new Applications();
            int listSize = 0;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите размер массива продуктов.");
                if (!int.TryParse(Console.ReadLine(), out listSize) || listSize <= 0)
                    Console.WriteLine("Введите положительное число.");
                else
                    flag = false;
            }

            applications.AddApp(listSize);
            applications.SortApp();
            applications.SaveFile();
        }
    }
}
