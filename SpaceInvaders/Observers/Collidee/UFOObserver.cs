

namespace SpaceInvaders
{
    public class UFOObserver : Observer
    {
        public override void Notify()
        {
            UFOLeaf Hit = (UFOLeaf)subject.ObjB;
            if (Hit.MarkForDeath == false)
            {
                RemoveMan.Add(new RemoveUFO(Hit));

                GameSprite temp = GameSpriteMan.Find(GameSpriteName.UFODeath);
                temp.x = Hit.x;
                temp.y = Hit.y;
                PlayBatchMan.Find(BatchName.DeadObj).Add(temp);

                CommandBase RemoveDeath = new RemoveDeath(temp);
                TimerMan.Add(RemoveDeath, 0.5f);

            }

            TimerMan.Remove(UFOMovingCommand.GetInstance());
            SoundMan.Stop();


        }
    }
}
