
namespace SpaceInvaders
{
    public class ShipBulletObserver : Observer
    {    
        public override void Notify()
        {
            ShipBulletLeaf Hit = (ShipBulletLeaf)subject.ObjA;
            if (Hit.MarkForDeath == false)
            {
                Hit.MarkForDeath = true;
                RemoveMan.Add(new RemoveBullet(Hit));
            }
        }
    }
}
