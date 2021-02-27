using System;
using System.Collections.Generic;
using System.Text;

namespace ReversedFunction
{

    class ReversedFunction
    {
        static public event Action<double> AccuracyUpdated;

        public static double reversedFunction((double a, double b) boundaries, Func<double, double> function, double y, double epsilon)
        {
            bool raising = function(boundaries.b) - function(boundaries.a) > 0;
            double fx, accuracy;
            double leftBound = boundaries.a;
            double rightBound = boundaries.b;
            double center;

            do
            {
                center = (leftBound + rightBound) / 2;
                fx = function(center);

                if ((fx < y && !raising) || (fx > y && raising))
                    rightBound = center;
                else
                    leftBound = center;

                accuracy = rightBound - leftBound;
                AccuracyUpdated?.Invoke(accuracy);

            } while (accuracy > epsilon);

            return (rightBound + leftBound) / 2;

        }
    }
}
