using System;

namespace Pathfinding
{
    public class Program
    {
        private const int _height = Settings.Height;
        private const int _width = Settings.Width;
        static void Main(string[] args)
        {
            KindManager.Init();
            string startCode = Settings.StartVal;

            World world = new World(_height, _width,startCode);
            world.Print();

            SearchTree st = new SearchTree(world);
            st.SearchForDestination();
            world.Print();
        }
    }
}
