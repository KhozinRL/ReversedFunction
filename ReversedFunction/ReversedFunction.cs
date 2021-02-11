using System;
using System.Collections.Generic;
using System.Text;

namespace ReversedFunction
{

    class ReversedFunction
    {
        static public event Action<string, object> AccuracyUpdated;

        public static double reversedFunction((double a, double b) boundaries, Func<double, double> function, double y, double epsilon)
        {
            AccuracyUpdated?.Invoke("Достигнутая точность: {0:f6}", boundaries.b - boundaries.a);

            if (Math.Abs(boundaries.a - boundaries.b) <= epsilon)
                return (boundaries.a + boundaries.b) / 2;

            double center = (boundaries.b + boundaries.a) / 2;

            Boolean raising = function(boundaries.b) - function(boundaries.a) > 0 ? true : false;

            if ((function(center) < y && raising == false) || (function(center) > y && raising))
            {
                return reversedFunction((boundaries.a, center), function, y, epsilon);
            }
            else
            {
                return reversedFunction((center, boundaries.b), function, y, epsilon);
            }
        }
    }
}
