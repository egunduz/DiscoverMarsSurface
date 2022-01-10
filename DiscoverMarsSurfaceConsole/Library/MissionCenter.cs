using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// This is a crucial mission aims to discover Mars surface.
    /// Below is virtual cocpit of the Main Machine leads a squad of robotic rovers to be land on Mars surface.
    /// Main machine can give commands to rovers inorder get a complate picture of the desired plateaus on mars surface
    /// </summary>
    public class MissionCenter
    {
        const int MAX_ROVER_LIMIT = 50;

        IList<Rover> m_Rovers;
        Plateau m_Plateau;

        public MissionCenter()
        {
            m_Rovers = new List<Rover>(MAX_ROVER_LIMIT);
            m_Plateau = new Plateau(new Point(0, 0));
        }

        /// <summary>
        /// creates a platue with given dimensions
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CreatePlatue(string coordinates) {

            IPoint upperRightCorner = Extensions.ConvertToPoint(coordinates);

            m_Plateau = new Plateau(upperRightCorner);
        }

        /// <summary>
        /// Creat a Rover and land on surface according to the given coordination and instructions
        /// </summary>
        /// <param name="coordinations">e.g 1 2 N</param>
        /// <param name="instructions">e.g MMRRLLM</param>
        public void DeployRover(string coordinates, string instructions)
        {
            if (m_Rovers.Count == MAX_ROVER_LIMIT)
                throw new DiscoverMarsSurfaceException($"Maxiumum Rover deployment limit ({MAX_ROVER_LIMIT}) exceeded!");

            string[] coordinationSet = coordinates?.Trim()?.Split(' ');
            if (coordinationSet == null || coordinationSet.Length != 3)
                throw new DiscoverMarsSurfaceException(ErrorCode.ROVER_LANDING_ERR, "Rover coordinates should be defined with three parameters splittet by space. For example: 1 2 N");

            IPoint intialLocation = Extensions.ConvertToPoint(coordinates);
            string initialDirection = coordinationSet[2];
            string name = $"Rover{m_Rovers.Count + 1}";

            var rover = new SmartRover(name, 
                intialLocation, 
                initialDirection);

            m_Rovers.Add(rover);

            rover.Proceed(instructions);
        }

        /// <summary>
        /// returns last status of rovers at the end of the mission
        /// </summary>
        /// <returns></returns>
        public string GetLastLocatsionsOfRovers()
        {
            StringBuilder sbResult = new StringBuilder();
            foreach (var rover in m_Rovers)
            {
                sbResult.AppendLine(rover.GetPrintableLocaion(true));
            }

            return sbResult.ToString();
        }
    }
}
