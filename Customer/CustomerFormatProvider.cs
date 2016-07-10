using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class CustomerFormatProvider: IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {

            if (format == null || (arg == null))
                throw new ArgumentNullException();
            

            if (arg.GetType() != typeof(Customer))
            {
                throw new FormatException(String.Format("The invalid format"));
            }


            Customer customer = (Customer)arg;

            format = format.ToUpperInvariant();
            StringBuilder result = new StringBuilder("Customer record: ");

            if (format == "G")
                format = "NPR";
            if (format.Contains("N"))
                result.Append(customer.Name.ToString() + "; ");
            if (format.Contains("P"))
                result.Append(customer.Phone.ToString() + "; ");
            if (format.Contains("R"))
                result.Append(customer.Revenue.ToString() + "; ");

            return result.ToString();
        }
    }

}
