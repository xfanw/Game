
using System;

namespace SpaceInvaders
{
    
    public class Rand
    {
        public static Random pRandom = new Random();

        public static int GetNext(int a, int b)
        {
            return pRandom.Next(a, b);
        }

    }
}
