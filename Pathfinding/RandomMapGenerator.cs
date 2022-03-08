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

            float maxStartPointInRatio = 0.2f;

            float minDestinationPointInRatio = 0.8f;

            for (int i = 0; i < length; i++)
            {
                retVal[i] = 'F';
            }

            Random random = new Random();

            int startPos = random.Next((int)((float)length*maxStartPointInRatio));
            retVal[startPos] = 'S';

            int destPos = -1;
            do
            {
                destPos = random.Next((int)((float)length * minDestinationPointInRatio), length);
            } while (destPos == startPos);

            retVal[destPos] = 'D';

            int countOfFreeFields = length - 2;
            float maxBlockedRatio = 0.5f;

            int maxBlockedTotal = (int)((float)countOfFreeFields * maxBlockedRatio);

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
