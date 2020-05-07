namespace SpaceInvaders
{
    public class HitAlienObserver:Observer
    {
        public override void Notify()
        {
            AlienLeaf Hit = (AlienLeaf)this.subject.ObjB;
            if (Hit.MarkForDeath == false)
            {
                Hit.MarkForDeath = true;
                RemoveMan.Add(new RemoveAlien(Hit));

                GameSprite temp = GameSpriteMan.Find(GameSpriteName.AlienDeath);
                temp.x = Hit.x;
                temp.y = Hit.y;
                PlayBatchMan.Find(BatchName.DeadObj).Add(temp);

                CommandBase RemoveDeath = new RemoveDeath(temp);
                TimerMan.Add(RemoveDeath, 0.5f);

            }

            Nums.AlienNum--;
            if (Nums.AlienNum == 0)
            {
                Nums.Level++;
                Nums.AlienNum = 55;
                AlienGridMan.InitializeGrid();
            }
        }
    }
}
