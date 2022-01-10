using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// some handy functions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// return only first letter represents the direction.
        /// e.g North = N
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static string ToCompassLetter(this CompassDirection direction)
        {
            return $"{direction}"?.Substring(0, 1);
        }

        /// <summary>
        /// return enum according to letter given
        /// e.g North = N
        /// </summary>
        /// <param name="compassLetter">N/E/W/S</param>
        /// <returns></returns>
        public static CompassDirection ToCompassEnum(this string compassLetter)
        {
            switch (compassLetter?.ToUpper())
            {
                case "N": return CompassDirection.North;
                case "E": return CompassDirection.East;
                case "S": return CompassDirection.South;
                case "W": return CompassDirection.West;

                default: 
                    throw new DiscoverMarsSurfaceException(ErrorCode.COMPASS_ERR, $"Invalid compass letter: {compassLetter}. Try any of these: N, E, S, W");
            }
        }

        /// <summary>
        /// gives printable location in formatted string
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static string ToFormattedSting(this IPoint point)
        {
            return $"{point?.AxisX} {point?.AxisY}";
        }

        /// <summary>
        /// gives printable location in formatted string
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static IPoint ConvertToPoint(this string coordinates)
        {
            string[] coordinationSet = coordinates?.Split(' ');
            if (coordinationSet == null || coordinationSet.Length < 2)
                throw new DiscoverMarsSurfaceException(ErrorCode.COORDINATION_PARAMETER_ERR, "Coordinates should be defined with two parameters splitted by a space. For example: 1 2");

            if (!Int64.TryParse(coordinationSet[0], out long axisX))
                throw new DiscoverMarsSurfaceException(ErrorCode.COORDINATION_PARAMETER_ERR, $"Invlaid number for x-axis: {coordinationSet[0]}");

            if (!Int64.TryParse(coordinationSet[1], out long axisY))
                throw new DiscoverMarsSurfaceException(ErrorCode.COORDINATION_PARAMETER_ERR, $"Invlaid number for y-axis: {coordinationSet[1]}");

            return new Point(axisX, axisY);
        }
    }
}
