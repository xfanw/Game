
namespace SpaceInvaders
{
    public class RemoveDeath : CommandBase
    {
        // Singleton Pattern
        private GameSprite _GameSprite;
        private TimerEvent Parent;

        public RemoveDeath(GameSprite sprite)
        {
            _GameSprite = sprite;
        }

        public override void SetTimerEvent(TimerEvent timer)
        {
            Parent = timer;
        }

        public override TimerEvent GetTimerEvent()
        {
            return Parent;
        }

        // Command
        public override void Run()
        {
            PlayBatchMan.Find(BatchName.DeadObj).Remove(_GameSprite);
            TimerMan.Remove(this);
        }

        public override string ToString()
        {
            return "Remove Death";
        }
    }
}
