using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// will be specialized if needed
    /// </summary>
    public class DiscoverMarsSurfaceException : Exception
    {
        public DiscoverMarsSurfaceException(string code) : base(code)
        {
        }

        public DiscoverMarsSurfaceException(string code, string message) : base($"{code} - {message}")
        {
        }
    }

    public static class ErrorCode
    {
        public const string COMPASS_ERR = "COMPASS_ERROR";
        public const string SMARTROVER_ERR = "SMARTROVER_ERROR";
        public const string ROVER_LANDING_ERR = "ROVER_LANDING_ERR";
        public const string COORDINATION_PARAMETER_ERR = "COOERTONATION_PARAMETER_ERROR";

    }
}
