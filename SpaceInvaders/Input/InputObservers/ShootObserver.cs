
namespace SpaceInvaders
{
    class ShootObserver : Observer
    {
        public override void Notify()
        {
            ShipMan.GetShip().ShootMissile();    
        }
    }
}