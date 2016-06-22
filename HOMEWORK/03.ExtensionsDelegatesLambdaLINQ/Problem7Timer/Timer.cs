namespace Problem7
{
    using System;
    using System.Threading;

    public class Timer
    {
        public delegate void TimerDelegate();

        private double timeInterval;
        private byte repetitions;

        public TimerDelegate PassedMethods { get; set; }

        public double TimeInterval
        {
            get
            {
                return this.timeInterval;
            }
            private set
            {
                if (value <= 0 )
                {
                    throw new ArgumentOutOfRangeException("Time interval must be a positive number!");
                }
                else
                {
                    this.timeInterval = value;
                }
            }
        }

        public byte Repetitions
        {
            get
            {
                return this.repetitions;
            }
            private set
            {
                if (value < 0 || value >255)
                {
                    throw new ArgumentOutOfRangeException("Repetitions must be between 1 and 255!");
                }
                else
                {
                    this.repetitions = value;
                }
            }
        }

        public Timer(double seconds, byte repetitions)
        {
            this.TimeInterval = seconds;
            this.Repetitions = repetitions;
        }

        public void ExecuteMethods ()
        {
            byte rounds = this.Repetitions;
            while (rounds > 0)
            {
                this.PassedMethods();
                Thread.Sleep((int)(this.TimeInterval * 1000));
                rounds--;
            }
        }


    }
}
