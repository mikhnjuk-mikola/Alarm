using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace New_04_11
{[Serializable]
    internal class Osnova
    {
        private static readonly List<Alarm> Alarms = new List<Alarm>();

        private static void Main()
        {
            LoadAlarms();

           
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
                        string newAlarmName;
                        do
                        {
                            Console.WriteLine("Введите название будильника");
                            newAlarmName = Console.ReadLine();
                        } while (IsAlarmWithNameExist(newAlarmName));

                        while (true)
                        {
                            Console.WriteLine("Введите время дзвонка");
                            Console.WriteLine("Формат ввода:ДД.ДД.ДД ВВ:ВВ:ВВ");
                            DateTime alarmTime;
                            if (DateTime.TryParse(Console.ReadLine(), out alarmTime))
                            {
                                if (alarmTime < DateTime.Now)
                                {
                                    Console.WriteLine(
                                        "Не верний формат ввода будильника. Будильник не может бить в прошедшем времени");
                                    continue;
                                }

                                var newAlarm = new Alarm(newAlarmName, alarmTime);
                                newAlarm.Run();

                                Alarms.Add(newAlarm);

                                Console.WriteLine("Будильник был успешно установлен на: " + alarmTime);
                                break;
                            }
                        }
                    }
                    if (actionNumber == 2)
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите время дзвонка или введите \"4\" для выхода в главное меню");

                            var input = Console.ReadLine();
                            if (input == "4")
                            {
                                break;
                            }

                            var alarmForDelete = Alarms.FirstOrDefault(a => a.Name == input);
                            if (alarmForDelete != null)
                            {
                                Alarms.Remove(alarmForDelete);

                                Console.WriteLine("удалено");
                                break;
                            }

                            Console.WriteLine("ну найден");
                        }
                    }
                    if (actionNumber == 3)
                    {
                        foreach (var alarm in Alarms)
                        {
                            Console.WriteLine("{0} - {1} - {2}", alarm.Name, alarm.DateTime, alarm.IsActive);
                        }
                    }
                    if (actionNumber == 4)
                    {
                        SaveAlarms();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод, повторите попытку");
                }
            }
            Console.Read();
         
          
        }

        private static void LoadAlarms()
        {
            using (FileStream fs = new FileStream("Alarm.xml", FileMode.OpenOrCreate))
            {                
                Alarm newAlarm = (Alarm)formater.Deserialize(fs);
            }

        }

       private static void SaveAlarms()
        {
            XmlSerializer formater = new XmlSerializer(typeof(Alarm));
            using (FileStream fs = new FileStream("Alarm.xml", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, Alarms);
            }
        }

        private static bool IsAlarmWithNameExist(string alarmName)
        {
            var result = false;

            foreach (var alarm in Alarms)
            {
                if (alarm.Name == alarmName && alarm.IsActive)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}