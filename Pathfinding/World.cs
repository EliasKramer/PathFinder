﻿namespace Pathfinding
{
    public class World
    {
        private int _height;
        private int _width;
        private Field[,] _internArr;
        private Field _startField;
        public World(int givenHeight, int givenWidth, string startCode)
        {
            _height = givenHeight;
            _width = givenWidth;

            _internArr = new Field[_height, _width];

            StartCodeIsValid(startCode);

            for (int h = 0; h < _height; h++)
            {
                for (int w = 0; w < _width; w++)
                {
                    int strIdx = IndexForCordinates(h, w);
                    string str = GetCharAt(startCode, strIdx);
                    Kind kindToAssign = Kind.Free;
                    if (str != null)
                    {
                        kindToAssign = KindManager.StringToKind(str, KindStringLength.Short);
                    }
                    Field fieldToAssign = new Field(kindToAssign, strIdx);

                    if (kindToAssign == Kind.StartPoint)
                    {
                        if (_startField == null)
                        {
                            _startField = fieldToAssign;
                        }
                        else
                        {
                            throw new Exception("More than one start field");
                        }
                    }

                    _internArr[h, w] = fieldToAssign;
                }
            }
            if (_startField == null)
            {
                throw new Exception("No start field");
            }
        }
        private string GetCharAt(string str, int idx)
        {
            if (idx < 0 || idx >= str.Length)
            {
                return null;
            }
            return Char.ToString(str[idx]);
        }
        private void StartCodeIsValid(string str)
        {
            foreach (char curr in str)
            {
                if (KindManager.ContainsShortString(Char.ToString(curr)) == false)
                {
                    throw new Exception("Start Code does contain a character, that is not known");
                }
            }
            if (str.Length > (_height * _width))
            {
                throw new Exception("The Start Code is too long");
            }

        }
        private int IndexForCordinates(int h, int w)
        {
            return h * _width + w;
            //return  h* (_height - 1) + h + w;
        }
        public List<Field> GetNeigbours(int idx)
        {
            int h = idx / _width;// idx % _height;
            int w = idx % _width;

             List<Field> result = new List<Field>();

            result.Add(GetField(h, w + 1));
            result.Add(GetField(h, w - 1));
            result.Add(GetField(h + 1, w));
            result.Add(GetField(h - 1, w));

            result.RemoveAll(item => item == null);

            return result;
        }
        private Field GetField(int h, int w)
        {
            if (h < 0 || h >= _height || w < 0 || w >= _width)
            {
                return null;
            }
            return _internArr[h, w];
        }
        public Field StartField
        { get { return _startField; } }
        public void Print()
        {
            Console.Clear();
            for (int h = 0; h < _height; h++)
            {
                for (int w = 0; w < _width; w++)
                {
                    _internArr[h, w].Print();
                }
                Console.WriteLine();
            }
        }
    }
}
