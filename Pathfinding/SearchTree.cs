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
        public void SearchForDestination()
        {
            SetBranchForRoot(_root);
        }
        private void SetBranchForRoot(Node givenRoot)
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
                    DrawPathFromStartToDestination(branch);
                    return;
                }
            }
            _upperBranches.Remove(givenRoot);
            if (_upperBranches.Count != 0)
            {
                SetBranchForRoot(_upperBranches[0]);
            }

        }
        private List<Node> DrawPathFromStartToDestination(Node node)
        {
            List<Node> path = new List<Node>();

            Node curr = node.Root;
            while (curr != null)
            {
                if (curr.Root != null)
                {
                    path.Add(curr);
                }
                curr = curr.Root;
            }
            foreach (Node currPath in path)
            {
                currPath.Field.Kind = Kind.Path;
            }
            return path;
        }
    }
}
