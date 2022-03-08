using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class Node
    {
        private Field _field;
        private Node _root;
        private List<Node> _brachnes;

        public Node(Field field, Node root)
        {
            _field = field;
            _root = root;
            _brachnes = new List<Node>();
        }
        public Field Field { get { return _field; } }
        public Node Root { get { return _root; } }

        public List<Node> Brachnes
        {
            get
            {
                return _brachnes;
            }
            set
            {
                _brachnes = value;
            }
        }
    }
}
