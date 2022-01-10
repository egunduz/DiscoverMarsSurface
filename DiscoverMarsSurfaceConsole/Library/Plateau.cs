using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// any rectangular area on mars surface
    /// </summary>
    public class Plateau
    {
        protected IPoint UpperRigtCorner { get; set; }
        protected IPoint LowerLeftCorner { get; set; }

        public Plateau(IPoint upperRight)
        {
            UpperRigtCorner = upperRight;
            UpperRigtCorner = new Point(0, 0);
        }
    }
}
