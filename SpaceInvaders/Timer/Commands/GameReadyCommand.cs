

namespace SpaceInvaders
{
    public class GameReadyCommand : CommandBase
    {
        private static GameReadyCommand _GameReady;

        private GameReadyCommand()
        {

        }

        public static GameReadyCommand GetInstance()
        {
            if (_GameReady == null)
            {
                _GameReady = new GameReadyCommand();
            }
            return _GameReady;
        }
        public override void Run()
        {
            SceneContext.GetState().Handle();
            TimerMan.Remove(this);
        }

        public override string ToString()
        {
            return "Game Ready";
        }
    }
}
