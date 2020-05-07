
namespace SpaceInvaders
{
    class TwoObserver : Observer
    {
        public override void Notify()
        {
            SceneContext.GetState().Handle();
        }
    }
}