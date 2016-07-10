using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class Customer
    {
        private string phone;
        public string Name { get; set; }
        public decimal Revenue { get; set; }



        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                value = ToNumber(value);

                if (value.Length != 10)
                {
                    throw new ArgumentException("Phone number must contains 10 digits");
                }

                phone = string.Format("{0:+# (###) ###-####}", Convert.ToInt64(value));
            }
        }

        private string ToNumber(string str)
        {
            StringBuilder result = new StringBuilder();
            foreach (char symbol in str)
            {
                if (char.IsDigit(symbol))
                {
                    result.Append(symbol);
                }
            }
            return result.ToString();
        }


        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            Phone = phone;
            Revenue = revenue;
        }

        public override string ToString()
        {
            return ToString("G", null);
        }

        public string ToString(string format)
        {
            return ToString("G", null);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString("G", provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (format == null)
                throw new ArgumentNullException();

            return string.Format(format, (CustomerFormatProvider)provider, this);
        }

    }
}
