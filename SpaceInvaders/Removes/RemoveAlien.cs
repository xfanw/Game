namespace SpaceInvaders
{
    public class RemoveAlien : CommandBase
    {
        private AlienLeaf Hit;
        public RemoveAlien(AlienLeaf hit)
        {
            Hit = hit;
        }
        public override void Run()
        {
            Hit.MarkForDeath = false;
            PlayBatchMan.Find(BatchName.Aliens).Remove(Hit.GetProxy());
            PlayBatchMan.Find(BatchName.Box).Remove(Hit.CollisionObj.Box);
            GameObjectMan.Remove(Hit);
        }
        public override string ToString()
        {
            return "remove Alien";
        }
    }
}
