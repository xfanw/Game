
namespace SpaceInvaders
{
    class OneObserver : Observer
    {
        public override void Notify()
        {
            if (SceneContext.GetStateName().Equals( "Select"))
            {
                SceneContext.GetState().Handle();
            }
        }
    }
}