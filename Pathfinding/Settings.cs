using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public static class Settings
    {
        public const int Height = 10;
        public const int Width = 10;

        public const string StartVal = "SFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFD";
        
        public const bool ShallGenerateStartVal = true;

        public const PathPrintMode PrintModeForPath = PathPrintMode.Slow;
        //path settings (only matter when path print mode is on slow)
        public const int MsBetweenNewDrawnPath = 100;

        //print settings (only matter when ShallGenerateStartVal is true)
        public const int Iterations = 1000;

        public const bool ShallPrintStatusEveryIteration = true;
        public const float TimeBeforeNextPictureInSeconds = 1.5f;

        public const bool ShallOnlyPrintIfItFoundSomething = true;

        public enum PathPrintMode{
            Instant,
            Slow
        };

    }
}
