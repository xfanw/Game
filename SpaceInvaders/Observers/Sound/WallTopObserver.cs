

namespace SpaceInvaders
{
    public class WallTopObserver : Observer
    {
        public override void Notify()
        {
            SoundMan.Play(SoundName.Invader4);
        }
    }
}
