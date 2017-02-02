using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace тест_0
{
    class Program
    {

        static void Main(string[] args)
        {
            int wallet = 0;
            bool w = true;
            string[] product = new string[3];
            product[0] = "хлеб";
            product[1] = "пиво";
            product[2] = "чай";
            int[] price = new int[3];
            price[0] = 10;
            price[1] = 30;
            price[2] = 20;
            while (w)
            {
                Console.WriteLine("Я дома. На счету " + wallet + "$");

                Console.WriteLine("идти на работу или в магазин?");
                Console.WriteLine("Выйти из игры?Для выхода введите (выйти)");
                string q = Console.ReadLine();
                if (q == "на работу")
                {
                    wallet = Job(wallet);
                }


                else if (q == "в магазин")
                {
                    wallet = Store(wallet);
                }
                else if (q == "выйти")
                {
                    w = false;
                }
            }
        }

        public static int Job(int wallet)
        {
            string q;
            Console.WriteLine("Начать работу?");
            bool p = true;
            while (p)
            {
                q = Console.ReadLine();
                if (q == "да")
                {
                    wallet += 100;
                    Console.WriteLine("получено 100 $. на счету " + wallet + " $. Продолжить работу?");
                }
                else if (q == "нет")
                {
                    p = false;
                }
                else
                {
                    wallet -= 1000;
                    Console.WriteLine("Вам засунули лопату в жопу и заставили закопать 1000 $. НА ВАШЕМ СЧЕТУ " + wallet +
                                      " $. Вытащить лопату из задницы и продолжить работу?");

                }
            }
            return wallet;
        }

        public static int Store(int wallet)
        {
            string q;
            string[] product = new string[3];
            product[0] = "хлеб";
            product[1] = "пиво";
            product[2] = "чай";
            int[] price = new int[3];
            price[0] = 10;
            price[1] = 30;
            price[2] = 20;
            bool c = true;
            while (c)
            {

                Console.WriteLine("Вы в магазине. Для выхода введите (домой)");
                Console.WriteLine("На данный момент в магазине есть:");
                for (int i = 0; i < price.Length; i++)
                {
                    Console.WriteLine(product[i] + "-" + price[i]);
                }
                Console.WriteLine("Хотите добавить новый предмет в магазин?");
                q = Console.ReadLine();
                if (q == "да")
                {
                    product = addProduct(product);
                    price = addPrice(price);
                }
                else if (q == "нет")
                {
                    wallet = purchase(wallet, product, price);
                }
                else if (q == "домой")
                {
                    c = false;
                }
                else
                {
                    Console.WriteLine("ОШИБКА. Введите (да) или (нет). Для выхода из магазина введите (домой)");
                }
            }
            return wallet;
        }

        public static string[] addProduct(string[] product)
        {
            string[] productNext = new string[product.Length + 1];
            Console.WriteLine("Введите название товара");
            for (int i = 0; i < product.Length; i++)
            {
                productNext[i] = product[i];
            }
            productNext[productNext.Length - 1] = Console.ReadLine();
            product = productNext;
            return product;
        }

        public static int[] addPrice(int[] price)
        {
            int[] priceNext = new int[price.Length + 1];
            for (int i = 0; i < price.Length; i++)
            {

                priceNext[i] = price[i];

            }
            Console.WriteLine("Введите цену товара");
            bool result = false;
            while (!result)
            {
                result = int.TryParse(Console.ReadLine(), out priceNext[priceNext.Length - 1]);
                if (!result)
                {
                    Console.WriteLine("Попробуйте использовать целые числа");
                }
                else
                {
                    Console.WriteLine("Халявы не будет!");
                }
            }
            price = priceNext;
            return price;
        }

        public static int purchase(int wallet, string[] product, int[] price)
        {
            string q;
            bool u = true;
            while (u)
            {
                Console.WriteLine("Что вы хотите купить?");
                q = Console.ReadLine();
                for (int i = 0; i < product.Length; i++)
                {
                    if (q == product[i])
                    {
                        wallet -= price[i];
                        Console.WriteLine("Вы купили " + product[i] + " остаток на счету " + wallet + "");
                    }
                }
                if (q == "ничего")
                {
                    u = false;
                }
            }
            return wallet;
        }
    }
}
