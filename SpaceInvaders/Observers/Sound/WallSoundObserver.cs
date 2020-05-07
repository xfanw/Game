

namespace SpaceInvaders
{
    public class WallSoundObserver : Observer
    {
        public override void Notify()
        {
            SoundMan.Play(SoundName.HitWall);
        }
    }
}
