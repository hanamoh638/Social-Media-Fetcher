using System;
using System.Timers;

namespace WinFormsApp1
{
    public class FetchDataTimer
    {
        private System.Timers.Timer timer;
        private Action fetchDataCallback;

        public FetchDataTimer(Action fetchDataCallback)
        {
            this.fetchDataCallback = fetchDataCallback;
            timer = new System.Timers.Timer();
            timer.Interval = 900000;
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
        } 

        // Start the timer and invoke the fetchData
        public void Start()
        {
            fetchDataCallback.Invoke();
            timer.Start();
        }

        // Stop the timer from fetching data
        public void Stop()
        {
            timer.Stop();
        }

        // when the timer reaches the interval invoke the fetchData
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            fetchDataCallback.Invoke();
        }
    }
}
