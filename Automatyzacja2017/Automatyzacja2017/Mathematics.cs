using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatyzacja2017
{
    public class Mathematics
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Substract(double x, double y)
        {
            return x - y;
        }

        public double Multiple(double x, double y)
        {
            return x * y;
        }
        
        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                Console.WriteLine("Nie można dzielić przez zero");
                return 0;
            }

            //if (y == 0) throw new DivideByZeroException();
            else
                return x / y;
        }
        public double Divide2(double x, double y)
        {
            if (y == 0)
            {
                Console.WriteLine("Nie można dzielić przez zero");
                return 0;
            }

            //if (y == 0) throw new DivideByZeroException();
            else
                return x / y;
        }
    }
}
