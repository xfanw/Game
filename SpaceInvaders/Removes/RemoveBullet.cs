namespace SpaceInvaders
{
    public class RemoveBullet : CommandBase
    {
        private ShipBulletLeaf Hit;
        public RemoveBullet(ShipBulletLeaf hit)
        {
            Hit = hit;
        }

        public override void Run()
        {
            Hit.MarkForDeath = false;
            PlayBatchMan.Find(BatchName.ShipBullet).Remove(Hit.GetProxy());
            PlayBatchMan.Find(BatchName.Box).Remove(Hit.CollisionObj.Box);
            GameObjectMan.Remove(Hit);
        }

        public override string ToString()
        {
            return "remove bullet";
        }
    }
}
