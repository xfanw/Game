

namespace SpaceInvaders
{
    class ShipDeadState : ShipState
    {
        public override void Handle(ShipLeaf pShip)
        {
            pShip.SetState(ShipMan.StateName.Ready);
        }


        public override void MoveRight(ShipLeaf pShip) { }

        public override void MoveLeft(ShipLeaf pShip) { }

        public override void ShootMissile(ShipLeaf pShip) { }
    }
}
