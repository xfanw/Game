namespace SpaceInvaders
{
    public abstract class FallStrategy
    {
        public abstract void Fall(BombLeaf pBomb);
        public abstract void Reset(float posY);

    }
}

// End of File
