namespace SpaceInvaders
{
    public abstract class ShipState
    {
        // state()
        public abstract void Handle(ShipLeaf pShip);

        // strategy()
        public abstract void MoveRight(ShipLeaf pShip);
        public abstract void MoveLeft(ShipLeaf pShip);
        public abstract void ShootMissile(ShipLeaf pShip);

    }
}
