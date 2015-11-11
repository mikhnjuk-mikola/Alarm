using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace New_04_11
{
    internal class Osnova
    {
        private const string FileName = "Alarms.xml";
        private static List<Alarm> _alarms = new List<Alarm>();

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

                                _alarms.Add(newAlarm);

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

                            string input = Console.ReadLine();
                            if (input == "4")
                            {
                                break;
                            }

                            Alarm alarmForDelete = _alarms.FirstOrDefault(a => a.Name == input);
                            if (alarmForDelete != null)
                            {
                                _alarms.Remove(alarmForDelete);

                                Console.WriteLine("удалено");
                                break;
                            }

                            Console.WriteLine("ну найден");
                        }
                    }
                    if (actionNumber == 3)
                    {
                        foreach (Alarm alarm in _alarms)
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
        }

        private static void LoadAlarms()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof (List<Alarm>));

                if (!File.Exists(FileName)) return;

                using (var fs = new FileStream(FileName, FileMode.Open))
                {
                    _alarms = xmlSerializer.Deserialize(fs) as List<Alarm>;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't deserialize {0}", FileName);
            }
        }

        private static void SaveAlarms()
        {
            var xmlSerializer = new XmlSerializer(typeof (List<Alarm>));
            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, _alarms);
            }
        }

        private static bool IsAlarmWithNameExist(string alarmName)
        {
            bool result = false;

            foreach (Alarm alarm in _alarms)
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