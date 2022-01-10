using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// Interface for object location on map (et. surface) based on Cartesian system
    /// </summary>
    public interface IPoint
    {
        /// <summary>
        /// x-axis
        /// </summary>
        long AxisX { get; set; }
        /// <summary>
        /// y-axis
        /// </summary>
        long AxisY { get; set; }
    }
}
