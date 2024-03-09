using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLaba10;

namespace Laba11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //обобщенная коллекция
            Plants plants1 = new Plants();
            plants1.RandomInit();
            Plants plants2 = new Plants();
            plants2.RandomInit();

            Trees trees1 = new Trees();
            trees1.RandomInit();
            Trees trees2 = new Trees();
            trees2.RandomInit();

            Flowers flowers1 = new Flowers();
            flowers1.RandomInit();
            Flowers flowers2 = new Flowers();
            flowers2.RandomInit();

            Rose rose1 = new Rose();
            rose1.RandomInit();
            Rose rose2 = new Rose();
            rose2.RandomInit();

            Console.WriteLine("Созданная обобщенная коллекция");
            List <Plants> list1 = new List<Plants>(plants1, plants2, trees1, trees2, rose1, rose2);
            for (int i = 0; i < list1.Count; i++)
            { Console.WriteLine(list1[i]); }

            Console.WriteLine($"Емкость = {list1.Capacity}");
            Console.WriteLine($"Количество элементов = {list1.Count}");
            Console.WriteLine();

            Console.WriteLine("Добавление элементов в коллекцию");
            Plants plants = new Plants();
            plants.RandomInit();
            list1.Add( plants );
            Trees trees = new Trees();
            trees.RandomInit();
            list1.Add( trees );
            Rose rose = new Rose();
            rose.RandomInit();
            list1.Add ( rose );
            Flowers flowers = new Flowers();
            flowers.RandomInit();
            list1.Add(flowers);

            for (int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine(list1[i]);
            }
            Console.WriteLine($"Емкость = {list1.Capacity}");
            Console.WriteLine($"Количество элементов = {list1.Count}");
            Console.WriteLine();

            Console.WriteLine("Удаление элементов из коллекции");
            list1.Remove(plants1);
            list1.Remove(trees1);
            for (int i = 0; i < list1.Count; i++)
            { Console.WriteLine(list1[i]); }

            Console.WriteLine($"Емкость = {list1.Capacity}");
            Console.WriteLine($"Количество элементов = {list1.Count}");
        }
    }
}
