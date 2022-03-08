using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class Field
    {
        private Kind _kind;
        private int _indexInWorld;
        public Field(Kind givenKind, int indexInWorld)
        {
            _kind = givenKind;
            _indexInWorld = indexInWorld;
        }

        public Kind Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }
        public int Index
        {
            get { return _indexInWorld; }
        }

        public override string ToString()
        {
            return "[" + KindManager.KindToString(_kind,KindStringLength.Short) + "]";
        }
        public void Print()
        {
            Console.ForegroundColor = KindManager.GetColorOfKind(_kind);
            Console.Write(ToString());
            Console.ForegroundColor = KindManager.DefaultColor;
        }
    }
}
