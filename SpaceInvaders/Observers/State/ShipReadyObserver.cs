
namespace SpaceInvaders
{
    public class ShipReadyObserver : Observer
    {
        public override void Notify()
        {
            if (ShipMan.GetShip().GetStateName() != ShipMan.StateName.Ready)
            {
                ShipMan.GetShip().Handle();
            }
        }
    }
}
