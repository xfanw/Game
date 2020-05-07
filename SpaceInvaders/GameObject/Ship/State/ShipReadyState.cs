

namespace SpaceInvaders
{
    class ShipReadyState : ShipState
    {
        public override void Handle(ShipLeaf pShip)
        {
            pShip.SetState(ShipMan.StateName.Flying);
        }

        public override void MoveRight(ShipLeaf pShip)
        {
            pShip.x += Nums.ShipSpeed;
        }

        public override void MoveLeft(ShipLeaf pShip)
        {
            pShip.x -= Nums.ShipSpeed;
        }

        public override void ShootMissile(ShipLeaf Ship)
        {
            ShipMan.InitializeBullet();

            SoundMan.Play(SoundName.Shoot);

            // switch states
            Handle(Ship);
        }

    }
}
