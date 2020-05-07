
namespace SpaceInvaders
{
    public class BoomObserver : Observer
    {
        public override void Notify()
        {
            SoundMan.Play(SoundName.Explosion);
        }        
    }
}
