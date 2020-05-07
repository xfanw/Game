
namespace SpaceInvaders
{
    public class Score
    {
        private static int score = 0;
        private static int highest = 500;

        public static void Add(int sc)
         {
            score += sc;
        }

        public static int GetHighest()
        {
            if (score > highest) highest = score;
            return highest;
        }

        public static object GetCurrent()
        {
            return score;
        }

        public static void Reset()
        {
            score = 0;
        }
    }
}
