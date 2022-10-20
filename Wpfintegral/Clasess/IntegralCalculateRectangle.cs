using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfintegral.Clasess
{
    public class IntegralCalculateRectangle : ICalculatorIntegral
    {
        public double Calculate(double down, double up, int numIntaration, Func<double, double> subInterral)
        {
            if (up < down)
                throw new Exception("Переделы перепутаны местами");
            else if (numIntaration == 0){
                throw new Exception("кол-во разбиений=0");
            }
            else
            {
                double sum = 0;
                double h = (up - down) / numIntaration;

                for (int i = 0; i < numIntaration; i++)
                {
                    sum += subInterral(down + h * 0.5 + h * i);
                }
                return h * sum;
            }
        }
       
    }
}
