namespace Pathfinding
{
    public abstract class KindManager
    {
        private static List<KindPair> _internalPairs;
        public static ConsoleColor DefaultColor = ConsoleColor.White;
        public static void Init()
        {
            _internalPairs = new List<KindPair>();

            _internalPairs.Add(new KindPair("Free", "F",ConsoleColor.White, Kind.Free,true));
            _internalPairs.Add(new KindPair("Blocked", "B",ConsoleColor.Red, Kind.Blocked,true));
            _internalPairs.Add(new KindPair("Uncoverd", "C", ConsoleColor.Green, Kind.Uncoverd,false));
            _internalPairs.Add(new KindPair("Start", "S",ConsoleColor.Yellow, Kind.StartPoint,true));
            _internalPairs.Add(new KindPair("Destination", "D",ConsoleColor.DarkMagenta, Kind.Destination,true));
            _internalPairs.Add(new KindPair("Path", "P", ConsoleColor.Cyan, Kind.Path,false));
        }
        public static bool ContainsShortStringInGeneration(string s)
        {
            foreach (KindPair curr in _internalPairs)
            {
                if (curr.ShortString == s && curr.CanBeSetByStartCode == true)
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
        private bool _canBeSetByStartCode;
        public KindPair(string longStr, string shortStr, ConsoleColor color, Kind givenKind,bool canBeSetByStartCode)
        {
            if (_kind == Kind.None)
            {
                throw new ArgumentException("kind none not allowed");
            }
            _longString = longStr;
            _shortString = shortStr;
            _kind = givenKind;
            _color = color;
            _canBeSetByStartCode = canBeSetByStartCode;
        }
        public bool CanBeSetByStartCode
        {
            get { return _canBeSetByStartCode; }
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
