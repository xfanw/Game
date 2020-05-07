

namespace SpaceInvaders
{
    class ShipMissleFlyingState : ShipState
    {
        public override void Handle(ShipLeaf pShip)
        {
            pShip.SetState(ShipMan.StateName.Ready);
        }


        public override void MoveRight(ShipLeaf pShip)
        {
            pShip.x += Nums.ShipSpeed;
        }

        public override void MoveLeft(ShipLeaf pShip)
        {
            pShip.x -= Nums.ShipSpeed;
        }

        public override void ShootMissile(ShipLeaf pShip)
        {

        }
    }
}
