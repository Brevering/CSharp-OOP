namespace DefineClass
{
    using System;
    using System.Text;

    public class Display
    {
        private double? size = null;
        private int? colorsNbr = null;

        //CONSTRUCTORS

        public Display()
        {
            this.Size = size;
            this.ColorsNbr = colorsNbr;
        }

        public Display(double? size)
        {
            this.Size = size;
        }

        public Display(double? size, int? colorsNbr)
        {
            this.Size = size;
            this.ColorsNbr = colorsNbr;
        }

        //PROPERTIES
        public double? Size
        {
            get
            {
                return this.size;
            }
            private set
            {                
                    if (value <= 0 || value >= 15)
                    {
                        throw new ArgumentOutOfRangeException("Display size has to be greater than zero and smaller than 15 inches in diagonal");
                    }
                    else
                    {
                        this.size = value;
                    }                
            }
        }

        public int? ColorsNbr
        {
            get
            {
                return this.colorsNbr;
            }
            private set
            {
                    if (value <= 0 || value >= 2147483647)
                    {
                        throw new ArgumentOutOfRangeException("Display colors have to be greater than zero and fewer than 2 147 483 647");
                    }
                    else
                    {
                        this.colorsNbr = value;
                    }
                }
            }
        //METHODS

        public override string ToString()
        {
            var result = new StringBuilder();           

            if (this.size != null)
            {
                result.AppendFormat("\t Size: \t\t {0} inches", this.size)
                    .Append(Environment.NewLine);
            }
            else
            {
                result.Append("\t Size: \t\t " + GlobalConstants.NoInfo)
                    .Append(Environment.NewLine);
            }

            if (this.colorsNbr != null)
            {
                result.AppendFormat("\t\t Colors: \t {0}", this.colorsNbr)
                    .Append(Environment.NewLine);
            }
            else
            {
                result.Append("\t\t Colors: \t " + GlobalConstants.NoInfo)
                    .Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

    }
    }

