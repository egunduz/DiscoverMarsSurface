using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// interface to describe movement abilities
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// direction of your whicle/rover etc.
        /// </summary>
        CompassDirection Direction { get; set; }

        /// <summary>
        /// go forward
        /// </summary>
        void Move();

        /// <summary>
        /// turn left or rigt
        /// </summary>
        /// <param name="whicSide"></param>
        void Turn(Side whicSide);
    }
}
