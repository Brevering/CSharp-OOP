namespace DefineClass
{
    using System;
    public class Call
    {
        private DateTime date;
        private string number;
        private int duration;

        //CONSTRUCTOR
        public Call(DateTime date, string number, int duration)
        {
            this.Date = date;
            this.Number = number;
            this.Duration = duration;
        }

        // PROPERTIES

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            private set
            {
                this.date = value;
            }                    
        }
        
        public string Number
        {
            get
            {
                return this.number;
            }
            private set
            {
                this.number = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                this.duration = value;
            }
        }

        public override string ToString()
        {
            string result = $"{this.Date}\t\t{this.Number}\t\t{this.Duration}";

            return result.ToString();
        }
    }
}
