using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Alarm
    {
        public Alarm(string name)
        {
            name = Name;
        }
        public string Name { get; private set; }
        public static void Vvod()
        {
            while (true)
            {
                Console.WriteLine("Введите время дзвонка");
                Console.WriteLine("Формат ввода:ДД.ДД.ДД ВВ:ВВ:ВВ");
                DateTime alarmTime;
                if (DateTime.TryParse(Console.ReadLine(), out alarmTime))
                {
                    if (alarmTime < DateTime.Now)
                    {
                        Console.WriteLine("Не верний формат ввода будильника.Будильник не может бить в прошедшем времени");
                        break;
                    }
                    Task.Factory.StartNew(() => Follow(alarmTime));
                    Console.WriteLine("Будильник был успешно установлен на: " + alarmTime);
                    break;
                }
            }
        }
        public static void Follow(DateTime alarmTime)
        {

            var alarmTimeLocal = alarmTime;
            while (true)
            {
                if (DateTime.Now >= alarmTimeLocal)
                {
                    Console.Beep(1000, 3000);
                    Console.WriteLine("ДЗВОНОК!!!!!");
                    break;
                }

            }
        }
    }


}



