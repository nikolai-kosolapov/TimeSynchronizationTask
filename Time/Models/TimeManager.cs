using System;
using System.Timers;

namespace Time.Models
{
    public class TimeManager
    {
        #region[public]
        public TimeManager()
        {
            CurrentTime = DateTime.Now;
            Start();
        }

        public TimeManager(DateTime time)
        {
            CurrentTime = time;
            Start();
        }

        public DateTime CurrentTime { get; private set; }

        public void AddHour()
        {
            CurrentTime = CurrentTime.AddHours(1);
        }

        public void SubtractHour()
        {
            CurrentTime = CurrentTime.AddHours(-1);
        }


        #endregion

        #region[private]
        private void Start()
        {
            var timer = new Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentTime = CurrentTime.AddSeconds(1);
        }
        #endregion
    }
}