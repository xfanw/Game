
namespace SpaceInvaders
{
    class MoveRightObserver : Observer
    {
        public override void Notify()
        {
            ShipMan.GetShip().MoveRight();
        }
    }
}
