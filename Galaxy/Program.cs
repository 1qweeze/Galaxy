using System;
using System.Collections.Generic;

namespace ConsoleApp_FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Galaxy News!");
            IterateThroughList();
            Console.ReadKey();
        }

        private static void IterateThroughList()
        {
            var theGalaxies = new List<Galaxy>
            {
                new Galaxy() { Name="Tadpole", MegaLightYears=400, GalaxyType=new GType('S')},
                new Galaxy() { Name="Pinwheel", MegaLightYears=25, GalaxyType=new GType('S')},
                new Galaxy() { Name="Cartwheel", MegaLightYears=500, GalaxyType=new GType('L')},
                new Galaxy() { Name="Small Magellanic Cloud", MegaLightYears=.2, GalaxyType=new GType('I')},
                new Galaxy() { Name="Andromeda", MegaLightYears=3, GalaxyType=new GType('S')},
                new Galaxy() { Name="Maffei 1", MegaLightYears=11, GalaxyType=new GType('E')}
            };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears + ",  " + theGalaxy.GalaxyType);
            }

            // Ожидаемый вывод:
            //  Tadpole  400,  Спиральная
            //  Pinwheel  25,  Спиральная
            //  Cartwheel, 500,  Линзовидная
            //  Small Magellanic Cloud .2,  Неправильная
            //  Andromeda  3,  Спиральная
            //  Maffei 1,  11,  Эллиптическая
        }
    }

    public class Galaxy
    {
        public string Name { get; set; }
        public double MegaLightYears { get; set; }
        public GType GalaxyType { get; set; } // Используем GType
    }

    public class GType
    {
        private Type _type; // Приватное поле для хранения типа галактики

        public GType(char type)
        {
            switch (type)
            {
                case 'S':
                    _type = Type.Спиральная;
                    break;
                case 'E':
                    _type = Type.Эллиптическая;
                    break;
                case 'I':
                    _type = Type.Неправильная;
                    break;
                case 'L':
                    _type = Type.Линзовидная;
                    break;
                default:
                    throw new ArgumentException("Неверный тип галактики");
            }
        }

        // Переопределение метода ToString для вывода текстового представления типа галактики
        public override string ToString()
        {
            return _type.ToString();
        }

        private enum Type { Спиральная, Эллиптическая, Неправильная, Линзовидная }
    }
}