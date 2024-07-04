using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Applications
    {
        public List<App> Apps = new List<App>();

        public void AddApp(int listSize)
        {
            Console.Clear();
            for (int i = 0; i < listSize; i++)
            {
                decimal cost = 0.0M;
                string name, creator;
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine($"Введите стоимость {i + 1} продукта.");
                    if (!decimal.TryParse(Console.ReadLine(), out cost) || cost <= 0)
                        Console.WriteLine("Введите положительное число через точку или запятую.");
                    else
                        flag = false;
                }
                Console.WriteLine($"Введите название {i + 1} продукта.");
                name = Console.ReadLine();
                Console.WriteLine($"Введите производителя {i + 1} продукта.");
                creator = Console.ReadLine();

                App app = new App
                {
                    Cost = cost,
                    Name = name,
                    Creator = creator
                };

                Apps.Add(app);
                Console.WriteLine("Для продолжения нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Продукты успешно добавлены в количестве {Apps.Count} шт.");
            Console.WriteLine("Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }

        public void SortApp()
        {
            Apps.Sort((x, y) =>
            string.Compare($"{y.Creator} {y.Cost}", $"{x.Creator} {x.Cost}"));
            Console.WriteLine("Отсортированный список по убыванию 'Производитель + Цена'.");
            foreach (App app in Apps)
            {
                Console.WriteLine($"Название: {app.Name}, стоимость: {app.Cost}, производитель: {app.Creator}.");
            }
            Console.WriteLine("Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }

        public void SaveFile()
        {
            string json = JsonConvert.SerializeObject(Apps, Formatting.Indented);
            File.WriteAllText($"D:\\Bochagova\\info.json", json);
            Console.WriteLine("Файл info.json успешно создан и записан.");
        }
    }
}
