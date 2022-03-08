using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public abstract class KindManager
    {
        private static List<KindPair> _internalPairs;
        public static ConsoleColor DefaultColor = ConsoleColor.White;
        public static void Init()
        {
            _internalPairs = new List<KindPair>();

            _internalPairs.Add(new KindPair("Free", "F",ConsoleColor.White, Kind.Free));
            _internalPairs.Add(new KindPair("Blocked", "B",ConsoleColor.Red, Kind.Blocked));
            _internalPairs.Add(new KindPair("Uncoverd", "C", ConsoleColor.Green, Kind.Uncoverd));
            _internalPairs.Add(new KindPair("Start", "S",ConsoleColor.Yellow, Kind.StartPoint));
            _internalPairs.Add(new KindPair("Destination", "D",ConsoleColor.DarkMagenta, Kind.Destination));
            _internalPairs.Add(new KindPair("Path", "P", ConsoleColor.Cyan, Kind.Path));

        }
        public static bool ContainsShortString(string s)
        {
            foreach (KindPair curr in _internalPairs)
            {
                if (curr.ShortString == s)
                {
                    return true;
                }
            }
            return false;
        }
        public static string KindToString(Kind givenKind, KindStringLength length)
        {
            foreach (KindPair curr in _internalPairs)
            {
                if (curr.Kind == givenKind)
                {
                    return curr.GetStringWithLength(length);
                }
            }
            return null;
        }
        public static Kind StringToKind(string s, KindStringLength length)
        {
            foreach (KindPair curr in _internalPairs)
            {
                if (curr.GetStringWithLength(length) == s)
                {
                    return curr.Kind;
                }
            }
            return Kind.None;
        }
        public static ConsoleColor GetColorOfKind(Kind k)
        {
            foreach (KindPair curr in _internalPairs)
            {
                if (curr.Kind == k)
                {
                    return curr.Color;
                }
            }
            return DefaultColor;
        }
    }
    public class KindPair
    {
        private ConsoleColor _color;
        private string _longString;
        private string _shortString;
        private Kind _kind;
        public KindPair(string longStr, string shortStr, ConsoleColor color, Kind givenKind)
        {
            if (_kind == Kind.None)
            {
                throw new ArgumentException("kind none not allowed");
            }
            _longString = longStr;
            _shortString = shortStr;
            _kind = givenKind;
            _color = color;
        }
        public string String
        {
            get { return _longString; }
        }
        public string GetStringWithLength(KindStringLength length)
        {
            if (length == KindStringLength.Long)
            {
                return _longString;
            }
            else
            {
                return _shortString;
            }
        }
        public ConsoleColor Color
        {
            get { return _color; }
        }
        public string ShortString
        {
            get { return _shortString; }
        }
        public Kind Kind
        {
            get { return _kind; }
        }
    }
    public enum Kind
    {
        Free,
        Uncoverd,
        Blocked,
        StartPoint,
        Destination,
        Path,
        None
    }
    public enum KindStringLength
    {
        Short,
        Long
    }
}
