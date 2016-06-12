namespace DefineClass
{
    using System;
    using System.Text;

    public class Battery
    {
        private string model = null;
        private int? hoursidle = null;
        private int? hourstalk = null;
        private BatteryType batterytype;

        //CONSTRUCTORS
        public Battery()
        {
            this.Model = model;
            this.Hoursidle = hoursidle;
            this.Hourstalk = hourstalk;
            this.Batterytype = batterytype;
        }

        public Battery(string model)
        {
            this.Model = model;
        }

        public Battery(string model, int? hoursidle)
            :this(model)
        {
            this.Hoursidle = hoursidle;
        }

        public Battery(string model, int? hoursidle, int?hourstalk)
            : this(model, hoursidle)
        {
            this.Hourstalk = hourstalk;
        }

        public Battery(string model, int? hoursidle, int? hourstalk, BatteryType batterytype)
            : this(model, hoursidle, hourstalk)
        {
            this.Batterytype = batterytype;
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
        public int? Hoursidle
        {
            get { return this.hoursidle; }
            private set
            {
                if (value <= 0 || value >= 2147483647)
                {
                    throw new ArgumentOutOfRangeException("Hours idle must be greater than zero and less than 2 147 483 647");
                }
                else
                {
                    this.hoursidle = value;
                }
            }
        }

        public int? Hourstalk
        {
            get { return this.hourstalk; }
            private set
            {
                if (value <= 0 || value >= 2147483647)
                {
                    throw new ArgumentOutOfRangeException("Hours talk must be greater than zero and less than 2 147 483 647");
                }
                else
                {
                    this.hourstalk = value;
                }
            }
        }

        public BatteryType Batterytype
        {
            get { return this.batterytype; }
            set { this.batterytype = value; }
        }

        // METHODS

        public override string ToString()
        {
            var result = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(this.model))
            {
                result.Append("\t Model: \t " + this.model)
                    .Append(Environment.NewLine);
            }
            else
            {
                result.Append("\t Model: \t " + GlobalConstants.NoInfo)
                    .Append(Environment.NewLine);
            }

            if (this.hoursidle != null)
            {
                result.AppendFormat("\t\t Hours idle: \t {0}", this.hoursidle)
                    .Append(Environment.NewLine);
            }
            else
            {
                result.Append("\t\t Hours idle: \t " + GlobalConstants.NoInfo)
                    .Append(Environment.NewLine);
            }

            if (this.hourstalk != null)
            {
                result.AppendFormat("\t\t Hours talk: \t {0}", this.hourstalk)
                    .Append(Environment.NewLine);
            }
            else
            {
                result.Append("\t\t Hours talk: \t " + GlobalConstants.NoInfo)
                    .Append(Environment.NewLine);
            }

            
                result.AppendFormat("\t\t Battery type: \t {0}", this.batterytype.ToString())
                    .Append(Environment.NewLine);
           
            return result.ToString();
        }
    }
}
