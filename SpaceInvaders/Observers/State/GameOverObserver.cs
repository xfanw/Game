
namespace SpaceInvaders
{
    public class GameOverObserver : Observer
    {
        public override void Notify()
        {
            // Confirm No More Lives
            if (Nums.ShipLife == 1)
            {
                // Remove all Aliens to reserve
                AlienGridMan.KillAll();
                Batch DeadObj = PlayBatchMan.Find(BatchName.DeadObj);
                DeadObj = null;

                if (SceneContext.GetStateName().Equals("Play"))
                {
                    SceneContext.GetState().Handle();
                }

            }

            //CommandBase Ready = GameReadyCommand.GetInstance();
            //TimerMan.Add(Ready, 3);
        }
    }
}
