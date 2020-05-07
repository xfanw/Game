namespace SpaceInvaders
{
    public class RemoveUFO : CommandBase
    {
        private UFOLeaf Hit;
        public RemoveUFO(UFOLeaf hit)
        {
            Hit = hit;
        }
        public override void Run()
        {
            Hit.MarkForDeath = false;
            PlayBatchMan.Find(BatchName.UFO).Remove(Hit.GetProxy());
            PlayBatchMan.Find(BatchName.Box).Remove(Hit.CollisionObj.Box);
            GameObjectMan.Remove(Hit);
        }

        public override string ToString()
        {
            return "remove UFO";
        }
    }
}
