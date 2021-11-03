using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19App1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Модель  компьютера характеризуется  кодом и  названием марки компьютера,  типом процессора, частотой  работы процессора, объемом оперативной памяти, 
            //    объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.
            //    Создать список, содержащий 6 - 10 записей с различным набором значений характеристик.

            //Определить:

            //-все компьютеры с указанным процессором. Название процессора запросить у пользователя;

            //-все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;

            //-вывести весь список, отсортированный по увеличению стоимости;

            //-вывести весь список, сгруппированный по типу процессора;

            //-найти самый дорогой и самый бюджетный компьютер;

            //-есть ли хотя бы один компьютер в количестве не менее 30 штук ?
            List<Computer> computersList = new List<Computer>()
            {
                new Computer(){ Name = "MSI", TypeCPU = "Core i7", FreqCPU = 2.3, RAM = 32, HDD = 500, GPU = 8, Price = 350, Availability = 11 },
                new Computer(){ Name = "Asus", TypeCPU = "Core i5", FreqCPU = 2.9, RAM = 8, HDD = 512, GPU = 8, Price = 245, Availability = 55 },
                new Computer(){ Name = "Lenovo", TypeCPU = "Core i3", FreqCPU = 3.4, RAM = 16, HDD = 1000, GPU = 4, Price = 260, Availability = 2 },
                new Computer(){ Name = "HP", TypeCPU = "Core i7", FreqCPU = 3.4, RAM = 16, HDD = 512, GPU = 16, Price = 450, Availability = 14 },
                new Computer(){ Name = "Asus", TypeCPU = "Core i7", FreqCPU = 3.4, RAM = 32, HDD = 2000, GPU = 8, Price = 500, Availability = 17 },
                new Computer(){ Name = "Honor", TypeCPU = "Core i5", FreqCPU = 3.6, RAM = 16, HDD = 1000, GPU = 4, Price = 350, Availability = 46 },
                new Computer(){ Name = "Apple", TypeCPU = "Core i7", FreqCPU = 3.2, RAM = 32, HDD = 2000, GPU = 8, Price = 1050, Availability = 2 },
                new Computer(){ Name = "Asus", TypeCPU = "Core i3", FreqCPU = 3.4, RAM = 8, HDD = 512, GPU = 8, Price = 200, Availability = 6 }
            };
            Console.Write("Выберите тип процессора: ");
            string inputCPU = Console.ReadLine();
            List<Computer> cpu = computersList
                .Where(d => d.TypeCPU == inputCPU)
                .DefaultIfEmpty()
                .ToList();
            foreach (Computer d in cpu)
                if (d != null)
                {
                    Console.WriteLine($"{d.Name}, {d.Price} руб., {d.Availability} шт.");
                }
                else
                {
                    Console.WriteLine("Таких компьютеров нет");
                }
            Console.WriteLine();
            Console.Write("Укажите объем ОЗУ: ");
            int inputRam = Convert.ToInt32(Console.ReadLine());
            List<Computer> ram = computersList
                .Where(d => d.RAM >= inputRam)
                .DefaultIfEmpty()
                .ToList();
            foreach (Computer d in ram)
                if (d != null)
                {
                    Console.WriteLine($"{d.Name}, {d.RAM} ГБ, {d.Price} руб., {d.Availability} шт.");
                }
                else
                {
                    Console.WriteLine("Таких компьютеров нет");
                }
            Console.WriteLine("ХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХ");
            Console.WriteLine();
            Console.WriteLine("Cортировка по цене: ");
            List<Computer> computersPrice = computersList
                .OrderBy(d => d.Price)
                .ToList();
            foreach (Computer d in computersPrice)
                Console.WriteLine($"{d.Name}, {d.Price}");
            Console.WriteLine("ХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХ");
            Console.WriteLine();
            Console.WriteLine("Сортировка по типу процессора: ");
            List<Computer> typeCPU = computersList
                .OrderBy(d => d.TypeCPU)
                .ToList();
            foreach (Computer d in typeCPU)
                Console.WriteLine($"{d.Name}, {d.TypeCPU}");
            Console.WriteLine("ХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХ");
            Console.WriteLine();
            Console.WriteLine("Самый дорогой компьютер.");
            Computer maxPrice = computersList
                .OrderByDescending(d => d.Price)
                .First();
            Console.WriteLine($"{maxPrice.Name} - {maxPrice.Price} руб.");
            Console.WriteLine("ХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХ");
            Console.WriteLine();
            Console.WriteLine("Самый бюджетный компьютер.");
            Computer minPrice = computersList
                .OrderBy(d => d.Price)
                .First();
            Console.WriteLine($"{minPrice.Name} - {minPrice.Price} руб.");
            Console.WriteLine("ХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХХ");
            Console.WriteLine();
            Console.WriteLine("Есть ли хотя бы один компьютер в количестве не менее 30 штук: ");
            var computers30 = computersList
                .Any((d => d.Availability >= 30));
            if (computers30 == true)
            {
                Console.WriteLine("Да");
            }
            else
            {
                Console.WriteLine("Нет");
            }
            Console.ReadKey();
        }
        class Computer
        {
            public string Name { get; set; }
            public string TypeCPU { get; set; }
            public double FreqCPU { get; set; }
            public int RAM { get; set; }
            public int HDD { get; set; }
            public int GPU { get; set; }
            public double Price { get; set; }
            public int Availability { get; set; }

        }
    }
}
