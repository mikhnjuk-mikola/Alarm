using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Osnova
    {

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("БУДИЛЬНИК");
                Console.WriteLine("1-Добавить будильник");
                Console.WriteLine("2-Удалить будильник");
                Console.WriteLine("3-Просмотреть информацию о будильниках");
                Console.WriteLine("4-Вихoд");
                int actionNumber;
                if (int.TryParse(Console.ReadLine(), out actionNumber))
                {
                    if (actionNumber == 1)
                    {
                        Alarm.Vvod();
                    }
                    if (actionNumber == 2)
                    {
                    }
                    if (actionNumber == 3)
                    {
                    }
                    if (actionNumber == 4)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод, повторите попытку");
                }
            }

        }

    }
}
