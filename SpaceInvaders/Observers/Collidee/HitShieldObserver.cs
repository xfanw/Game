

namespace SpaceInvaders
{
    public class HitShieldObserver : Observer
    {
        public override void Notify()
        {
            ShieldBrick Hit = (ShieldBrick)subject.ObjB;
            if (Hit.MarkForDeath == false)
            {
                RemoveMan.Add(new RemoveBrick(Hit));
            }            
        }
    }
}
