
namespace SpaceInvaders
{
    public class UFOMovingCommand : CommandBase
    {
        // Singleton Pattern
        private GameObject UFO;
        private static UFOMovingCommand _UFOMove;
        private TimerEvent Parent;

        private UFOMovingCommand()
        {
            UFO = (GameObject)GameObjectMan.Find(50, 50).GameObj.GetFirstChild();
        }

        public override void SetTimerEvent(TimerEvent timer)
        {
            _UFOMove.Parent = timer;
        }

        public override TimerEvent GetTimerEvent()
        {
            return _UFOMove.Parent;
        }
        public static UFOMovingCommand GetInstance()
        {
            if (_UFOMove == null)
            {
                _UFOMove = new UFOMovingCommand();
            }
            return _UFOMove;
        }

        // Command
        public override void Run()
        {
            UFO.MoveX();
        }

        public override string ToString()
        {
            return "UFO Moving";
        }
    }
}
