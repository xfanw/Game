
namespace SpaceInvaders
{
    public class BombObserver : Observer
    {
        public override void Notify()
        {
            GameObject Hit = subject.ObjA;
            if (Hit.MarkForDeath == false)
            {
                Hit.MarkForDeath = true;
                RemoveMan.Add(new RemoveBomb(Hit));
            } 
        }
    }
}
