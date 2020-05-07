
using System;

namespace SpaceInvaders
{
    public class AlienFasterCommand : CommandBase
    {
        public override void Run()
        {
            if (Math.Abs(Nums.AlienDeltaX )< 7f)
            {
                // Aliens Delt X get larger
                Nums.AlienDeltaX *= 1.1f;

                // Aliens marching sound interval get smaller
                Nums.SoundInterval /= 1.1f;
            }
        }


        public override string ToString()
        {
            return "Alien Faster Cmd";
        }
    }
}
