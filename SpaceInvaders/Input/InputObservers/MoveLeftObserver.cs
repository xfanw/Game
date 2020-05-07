
namespace SpaceInvaders
{
    class MoveLeftObserver : Observer
    {
        public override void Notify()
        {            
            ShipMan.GetShip().MoveLeft();
        }

    }
}
