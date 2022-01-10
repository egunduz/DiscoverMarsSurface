using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// a smart whicle that will help you to discover mars surface
    /// </summary>
    public class Rover : IMovable
    {
        /// <summary>
        /// any name or letter describes your whicle
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// rover's location on the map
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// direction of your whicle/rover etc.
        /// </summary>
        public CompassDirection Direction { get; set; }

        /// <summary>
        /// construction
        /// </summary>
        /// <param name="name">any name</param>
        public Rover(string name)
        {
            Name = name;
        }

        /// <summary>
        /// move rover forward side
        /// </summary>
        public void Move()
        {
            switch (Direction)
            {
                case CompassDirection.North:
                    Location.AxisY++; //  move forward on y-axis
                    break;

                case CompassDirection.East:
                    Location.AxisX++; //  move forward on x-axis
                    break;

                case CompassDirection.South:
                    Location.AxisY--; //  move forward on y-axis
                    break;

                case CompassDirection.West:
                    Location.AxisX--; //  move forward on x-axis
                    break;
            }
        }

        /// <summary>
        /// turn your rover on left or right
        /// </summary>
        /// <param name="whicSide"></param>
        public void Turn(Side whicSide)
        {
            // each time your Rover can only be rotated 90 degrees
            // if you turn on rigt 90; otherwise on left -90 degree is the rotaion amount
            // here how I calculated it in order to minimize the code 
            int currentAngle = (int)Direction;
            int rotation = (whicSide == Side.Right ? 1 : -1) * 90;
            int newAngle = ((currentAngle == 0 ? 360 : currentAngle) + rotation) % 360; // bugfix for Nort direction
            Direction = (CompassDirection)newAngle;
        }

        /// <summary>
        /// gives formatted location for any printing porpuse
        /// </summary>
        /// <returns></returns>
        public string GetPrintableLocaion(bool includeName = false)
        {
            string formattedLocation = $"{Location.ToFormattedSting()} {Direction.ToCompassLetter()}";

            if (includeName)
                formattedLocation = $"{Name}: {formattedLocation}";

            return formattedLocation;
        }
    }
}
