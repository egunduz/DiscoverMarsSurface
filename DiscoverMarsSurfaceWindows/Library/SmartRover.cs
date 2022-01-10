using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// A smarter rover that has ability to proceed letter defined (M, L, R) commands
    /// </summary>
    public sealed class SmartRover: Rover
    {
        public SmartRover(string name, IPoint intialLocation, string initialDirection): base(name)
        {
            if (intialLocation == null)
                throw new DiscoverMarsSurfaceException(ErrorCode.SMARTROVER_ERR, $"invalid initial location for rover {name}");

            if (initialDirection == null)
                throw new DiscoverMarsSurfaceException(ErrorCode.SMARTROVER_ERR, $"invalid initial direction for rover {name}");

            Location = new Point(intialLocation.AxisX, intialLocation.AxisY);
            Direction = initialDirection.ToCompassEnum();
        }

        /// <summary>
        /// proceeds the insructions
        /// </summary>
        ///<param name="instructions">eg. MMLRM</param>
        public void Proceed(string instructions)
        {
            foreach (char letter in instructions)
            {
                switch (letter)
                {
                    case 'M':
                    case 'm':
                        Move();
                        break;

                    case 'R':
                    case 'r':
                        Turn(Side.Right);
                        break;

                    case 'L':
                    case 'l':
                        Turn(Side.Left);
                        break;
                }
            }
        }
    }
}
