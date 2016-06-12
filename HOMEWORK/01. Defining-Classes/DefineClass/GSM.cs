namespace DefineClass
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        private string model; 
        private string manufacturer; 
        private double? price = null; 
        private string owner = null; 
        private Battery battery = new Battery(); 
        private Display display = new Display();

        public static GSM iPhone4S = new GSM("iPhone 4S", "Apple", 1600, "Kifla", new Battery("Unknown", 200, 8, BatteryType.LiPolymer), new Display(3.5, 16777216));

        private List<Call> callHistory = new List<Call>();

        //CONSTRUCTORS


        public GSM()            
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }


        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, double? price)
        :this(model, manufacturer)
        {
            this.Price = price;
        }

        public GSM(string model, string manufacturer, double? price, string owner)
            :this(model, manufacturer, price)
        {
            this.Owner = owner;
        }

        public GSM(string model, string manufacturer, double? price, string owner, Battery battery)
            :this(model, manufacturer, price, owner)
        {
            this.Battery = battery;
        }

        public GSM(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
            : this(model, manufacturer, price, owner, battery)
        {
            this.Display = display;
        }

        //PROPERTIES

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length <= 0 || value.Length >= 25)
                    {
                        throw new ArgumentOutOfRangeException(GlobalConstants.OutOfRangeMsg);
                    }
                    else
                    {
                        this.model = value;
                    }
                }
            }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (value.Length > 0 && value.Length <= 25)
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.OutOfRangeMsg);
                }
            }
        }
        public double? Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be zero or greater.");
                }
                else
                {
                   
                    this.price = value;
                }
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                this.owner = value;
            }
        }
        public Battery Battery
        {
            get { return this.battery; }
            private set { this.battery = value; }
        }
        public Display Display
        {
            get { return this.display; }
            private set { this.display = value; }
        }

        public static GSM IPhone4S
        {
            get
            { return iPhone4S; }
            set
            { iPhone4S = value; }
        }

        public List<Call> CallHistory 
        {
            get { return callHistory; }
            set { this.callHistory = value; }
        }

        //METHODS

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("Model: \t\t\t\t {0}", this.model)
                .Append(Environment.NewLine)
                .AppendFormat("Manufacturer: \t\t\t {0}", this.manufacturer)
                .Append(Environment.NewLine);

            if (this.price >= 0)
            {
                result.AppendFormat("Price: \t\t\t\t {0:F2} BGN", this.price)
                    .Append(Environment.NewLine);
            }
            else
            {
                result.Append("Price: \t\t\t\t "+ GlobalConstants.NoInfo)
                    .Append(Environment.NewLine);
            }

            if (!string.IsNullOrWhiteSpace(this.owner))
            {
                result.AppendFormat("Owner: \t\t\t\t {0}", this.owner)
                    .Append(Environment.NewLine);
            }
            else
            {
                result.Append("Owner: \t\t\t\t " + GlobalConstants.NoInfo)
                    .Append(Environment.NewLine);
            }

            if (this.battery != null)
            {
                result.Append("Battery:")
                    .Append(this.battery.ToString());
            }
            else
            {
                result.Append("Battery: \t " + GlobalConstants.NoInfo);
            }

            if (this.display != null)
            {
                result.Append("Display:")
                    .Append(this.display.ToString());
            }
            else
            {
                result.Append("Display: \t " + GlobalConstants.NoInfo)
                    .Append(Environment.NewLine);
            }
            return result.ToString();
        }

        public void ShowPhoneInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public void AddCall(DateTime date, string phoneNumber, int duration)
        {
            this.CallHistory.Add(new Call(date, phoneNumber, duration));
        }

        public void DeleteCall(Call call)
        {
            this.CallHistory.Remove(call);
        }

        public void ClearHistory()
        {
            this.CallHistory.Clear();
        }

        public double CalculateTotalPrice (List<Call> callsHistory, double pricePerMinute)
        {
            var fullDurationSeconds = 0;

            for (int i = 0; i < callsHistory.Count; i++)
            {
                fullDurationSeconds += callsHistory[i].Duration;
            }

            double minutes = (fullDurationSeconds / 60);
            double totalPrice = (Math.Ceiling(minutes)) * pricePerMinute;

            return totalPrice;
        }

        public void PrintCallHistory()
        {
            if (callHistory.Count == 0)
            {
                Console.WriteLine("There are no calls in call history!");
            }
            else
            {
                Console.WriteLine("Date\t\tTime\t\tDialed number\tDuration in seconds");
                foreach (var call in this.CallHistory)
                {
                    Console.WriteLine(call.ToString());
                }
            }

        }
    }
}
