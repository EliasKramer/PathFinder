using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    class SearchTree
    {
        private Node _root;
        private World _world;
        private List<Node> _upperBranches;
        public SearchTree(World w)
        {
            _world = w;
            _root = new Node(w.StartField, null);
            _upperBranches = new List<Node>();
            _upperBranches.Add(_root);
        }
        public bool SearchForDestination()
        {
            return SetBranchForRootAndSearchForDestination(_root);
        }
        private bool SetBranchForRootAndSearchForDestination(Node givenRoot)
        {
            List<Field> neighbourFields = _world.GetNeigbours(givenRoot.Field.Index);

            foreach (Field curr in neighbourFields)
            {
                givenRoot.Brachnes.Add(new Node(curr, givenRoot));
            }

            foreach (Node branch in givenRoot.Brachnes)
            {
                if (branch.Field.Kind == Kind.Free)
                {
                    branch.Field.Kind = Kind.Uncoverd;

                    _upperBranches.Add(branch);
                }
                if (branch.Field.Kind == Kind.Destination)
                {

                    List<Field> path = PathToDestination(branch);

                    if (Settings.PrintModeForPath == Settings.PathPrintMode.PrintPathSlow)
                    {
                        _world.SetAllCalculatedPathsToFree();
                        _world.Path = path;
                    }
                    return true;
                }
            }
            _upperBranches.Remove(givenRoot);
            if (_upperBranches.Count != 0)
            {
                if (Settings.PrintModeForPath == Settings.PathPrintMode.ShowSearchProcess)
                {
                    _world.Print();
                    if(Settings.MsBetweenSearchUpdates > 0)
                    {
                        Thread.Sleep(Settings.MsBetweenSearchUpdates);
                    }
                }
                return SetBranchForRootAndSearchForDestination(_upperBranches[0]);
            }
            return false;
        }
        private List<Field> PathToDestination(Node node)
        {
            List<Field> path = new List<Field>();

            Node curr = node.Root;
            while (curr != null)
            {
                if (curr.Root != null)
                {
                    path.Add(curr.Field);
                }
                curr = curr.Root;
            }
            if (Settings.PrintModeForPath == Settings.PathPrintMode.Instant ||
                Settings.PrintModeForPath == Settings.PathPrintMode.ShowSearchProcess)
            {
                foreach (Field currPath in path)
                {
                    currPath.Kind = Kind.Path;
                }
            }
            return path;
        }
    }
}
