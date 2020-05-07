namespace SpaceInvaders
{
    public class RemoveBrick : CommandBase
    {
        private ShieldBrick Hit;
        public RemoveBrick(ShieldBrick hit)
        {
            Hit = hit;
        }
        public override void Run()
        {
            Hit.MarkForDeath = false;
            PlayBatchMan.Find(BatchName.Bricks).Remove(Hit.GetProxy());
            PlayBatchMan.Find(BatchName.Box).Remove(Hit.CollisionObj.Box);
            GameObjectMan.Remove(Hit);
        }

        public override string ToString()
        {
            return "remove brick";
        }
    }
}
