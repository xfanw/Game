namespace SpaceInvaders
{
    public class RemoveBomb : CommandBase
    {
        private BombLeaf Hit;
        public RemoveBomb(GameObject hit)
        {
            Hit = (BombLeaf) hit;
        }
        public override void Run()
        {            
            Hit.MarkForDeath = false;
            PlayBatchMan.Find(BatchName.Bombs).Remove(Hit.GetProxy());
            PlayBatchMan.Find(BatchName.Box).Remove(Hit.CollisionObj.Box);
            GameObjectMan.Remove(Hit);
        }

        public override string ToString()
        {
            return "remove Bomb";
        }
    }
}
