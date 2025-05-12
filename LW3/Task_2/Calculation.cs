using System;

namespace Task_2
{
    public static class Calculation
    {
        public static (double y, string branch) Calculate(double n, double k, double m, double z)
        {
            double x;
            string branch;

            if (z > 1)
            {
                x = Math.Exp(z) + z;
                branch = "x = e^z + z";
            }
            else
            {
                x = Math.Pow(z, 2) + 1;
                branch = "x = z^2 + 1";
            }

            double y = Math.Sin(n * x) + Math.Cos(k * x) + Math.Log(m * x);
            return (y, branch);
        }
    }
}