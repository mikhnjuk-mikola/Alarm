using System;
using System.Threading.Tasks;

namespace New_04_11
{
    [Serializable]
    public class Alarm
    {
        public Alarm(string name, DateTime dateTime)
        {
            Name = name;
            DateTime = dateTime;

            IsActive = true;
        }
        public Alarm()
        {
        }

        public string Name { get;  set; }
        public DateTime DateTime { get;  set; }

        public bool IsActive { get;  set; }


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