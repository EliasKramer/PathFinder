using System;

namespace Pathfinding
{
    public class Program
    {
        private const int _height = Settings.Height;
        private const int _width = Settings.Width;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            World world = null;
            KindManager.Init();
            string startCode = Settings.StartVal;
            int iterations = Settings.Iterations;
            int foundTheWayCount = 0;
            float successRateInPercent = 0;
            bool lastWasFound = false;
            if (!Settings.ShallGenerateStartVal)
            {
                iterations = 1;
            }

            for (int i = 1; i <= iterations; i++)
            {
                if (Settings.ShallGenerateStartVal)
                {
                    startCode = RandomMapGenerator.GetRandomGeneratedEnvironment(_height, _width);
                }

                world = new World(_height, _width, startCode);

                lastWasFound = FoundPathInWorld(world);

                if (lastWasFound)
                {
                    foundTheWayCount++;
                }
                successRateInPercent = ((float)(foundTheWayCount) / (float)(i)) * 100;
                if ((Settings.ShallPrintStatusEveryIteration && Settings.ShallGenerateStartVal) &&
                    (!Settings.ShallOnlyPrintIfItFoundSomething || lastWasFound))
                {
                    PrintWorld(world, lastWasFound);

                    if (!Settings.ShallOnlyPrintIfItFoundSomething)
                    {
                        Console.WriteLine();
                        PrintDestinationFound(lastWasFound);
                        PrintSuccessRate(successRateInPercent);
                    }
                    Thread.Sleep((int)(Settings.TimeBeforeNextPictureInSeconds * 1000));
                }

            }
            PrintWorld(world, lastWasFound);
            Console.WriteLine();
            PrintDestinationFound(lastWasFound);
            if (Settings.ShallGenerateStartVal)
            {
                PrintSuccessRate(successRateInPercent);
            }
        }
        private static void PrintWorld(World w, bool slowPathPrintingAllowed)
        {
            if (Settings.PrintModeForPath == Settings.PathPrintMode.Slow && slowPathPrintingAllowed)
            {
                w.PrintPathSlow();
            }
            else
            {
                w.Print();
            }
        }
        private static void PrintDestinationFound(bool val)
        {
            Console.ForegroundColor = val ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Found the destination: {val} ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void PrintSuccessRate(float val)
        {
            Console.WriteLine($"successrate: {val:#00.00}% ");
        }
        private static bool FoundPathInWorld(World w)
        {
            SearchTree st = new SearchTree(w);
            return st.SearchForDestination();
        }
    }
}
