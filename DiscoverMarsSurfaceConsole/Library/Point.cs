using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// Gives location of any object on map (et. surface) based on Cartesian system
    /// </summary>
    public class Point : IPoint
    {
        public long AxisX { get; set; }
        public long AxisY { get; set; }

        /// <param name="x">x-axis</param>
        /// <param name="y">y-axis</param>
        public Point(long x, long y)
        {
            AxisX = x;
            AxisY = y;
        }
    }
}