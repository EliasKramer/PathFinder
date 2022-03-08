using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public static class RandomMapGenerator
    {
        public static string GetRandomGeneratedEnvironment(int h, int w)
        {
            int length = h * w;
            char[] retVal = new char[length];

            for (int i = 0; i < length; i++)
            {
                retVal[i] = 'F';
            }

            Random random = new Random();

            int startPos = random.Next((int)((float)length* Settings.StartPointRatio));
            retVal[startPos] = 'S';

            int destPos = -1;
            do
            {
                destPos = random.Next((int)((float)length * Settings.DestinationPointRatio), length);
            } while (destPos == startPos);

            retVal[destPos] = 'D';

            int countOfFreeFields = length - 2;

            int maxBlockedTotal = (int)((float)countOfFreeFields * Settings.BlockedRatio);

            for(int i = 0; i < maxBlockedTotal; i++)
            {
                int pos = random.Next(length);
                if(pos != startPos && pos != destPos)
                {
                    retVal[pos] = 'B';
                }
            }

            return new string(retVal);
        }
    }
}
