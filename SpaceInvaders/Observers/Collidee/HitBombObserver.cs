
namespace SpaceInvaders
{
    public class HitBombObserver : Observer
    {
        public override void Notify()
        {
            GameObject Hit = subject.ObjB;
            if (Hit.MarkForDeath == false)
            {
                Hit.MarkForDeath = true;
                RemoveMan.Add(new RemoveBomb(Hit));
            }
        }
    }
}
