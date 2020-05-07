using System.Diagnostics;

namespace SpaceInvaders{

    class FallCross : FallStrategy
    {
        private float oldPosY;
        public FallCross()
        {
            this.oldPosY = 0.0f;
        }

        public override void Reset(float posY)
        {
            this.oldPosY = posY;
        }

        public override void Fall(BombLeaf pBomb)
        {
            float targetY = oldPosY - 1.0f * pBomb.GetHeight();

            if (pBomb.y < targetY)
            {
                pBomb.MultiplyScale(1.0f, -1.0f);
                oldPosY = targetY;
            }
        }


    }
}

// End of File
