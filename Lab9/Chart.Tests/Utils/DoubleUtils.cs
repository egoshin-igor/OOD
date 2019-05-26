using System;

namespace Chart.Tests.Utils
{
    public static class DoubleUtils
    {
        public static bool EqualsDoubles( double first, double second )
        {
            var e = 0.01d;
            return Math.Abs( first - second ) < e;
        }
    }
}
