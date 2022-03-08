﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public static class Settings
    {
        public const int Height = 30;
        public const int Width = 30;

        public const string StartVal = "SFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFD";
        
        public const bool ShallGenerateStartVal = true;

        public const PathPrintMode PrintModeForPath = PathPrintMode.PrintPathSlow;
        //delay for showsearchprocess
        public const int MsBetweenSearchUpdates = 0;

        //path settings (only matter when path print mode is on PrintPathSlow)
        public const int MsBetweenNewDrawnPath = 10;

        //print settings (only matter when ShallGenerateStartVal is true)
        public const int Iterations = int.MaxValue;

        public const bool ShallPrintStatusEveryIteration = true;
        public const float TimeBeforeNextPictureInSeconds = 1f;

        public const bool ShallOnlyPrintIfItFoundSomething = true;

        //advanced generation settings

        //the percentage where the destination start cannot be
        //0.8 can be only be above 20% of the fields
        //0.2 can be only be above 80% of the fields
        public const float StartPointRatio = 0.2f;

        //the percentage where the destination adress can start
        //0.8 can be only lower than 80% of the fields
        //0.2 can be only lower than 20% of the fields
        public const float DestinationPointRatio = 0.8f;

        //if 0.5 half the blocks have a chance of getting blocked.
        //if it is getting over 1 it is really unlikely a path is found.
        public const float BlockedRatio = 0.8f;

        public const bool AllowDiagonals = true;
        public enum PathPrintMode{
            Instant,
            ShowSearchProcess,
            PrintPathSlow
        };

    }
}
