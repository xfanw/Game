using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class FallT : FallStrategy
    {
        private float oldPosY;
        public FallT()
        {
            oldPosY = 0.0f;
        }

        public override void Reset(float posY)
        {
            oldPosY = posY;
        }

        public override void Fall(BombLeaf pBomb)
        {

        }        
    }
}

// End of File
