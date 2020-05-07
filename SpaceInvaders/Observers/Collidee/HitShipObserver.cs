

namespace SpaceInvaders
{
    public class HitShipObserver : Observer
    {
        public override void Notify()
        {
            ShipLeaf Hit = (ShipLeaf)this.subject.ObjB;
            if (Hit.MarkForDeath == false)
            {
                Hit.MarkForDeath = true;
                RemoveMan.Add(new RemoveShip(Hit));

                if (Nums.ShipLife > 1)
                {
                    GameSprite temp = GameSpriteMan.Find(GameSpriteName.ShipDeath);
                    temp.x = Hit.x;
                    temp.y = Hit.y;
                    PlayBatchMan.Find(BatchName.DeadObj).Add(temp);

                    CommandBase RemoveDeath = new RemoveDeadShip(temp);
                    TimerMan.Add(RemoveDeath, 0.5f);
                }
            }
        }
    }
}

