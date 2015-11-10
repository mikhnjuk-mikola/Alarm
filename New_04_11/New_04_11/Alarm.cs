using System;
using System.Threading.Tasks;

namespace New_04_11
{
    public class Alarm
    {
        public Alarm(string name, DateTime dateTime)
        {
            Name = name;
            DateTime = dateTime;

            IsActive = true;
        }

        public string Name { get; private set; }
        public DateTime DateTime { get; private set; }

        public bool IsActive { get; private set; }


        private void Follow(DateTime alarmTime)
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

            IsActive = false;
        }

        public void Run()
        {
            Task.Factory.StartNew(() => Follow(DateTime));
        }
    }
}