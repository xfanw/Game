namespace SpaceInvaders
{
    public class RemoveShip : CommandBase
    {
        private ShipLeaf Hit;
        public RemoveShip(ShipLeaf hit)
        {
            Hit = hit;
        }
        public override void Run()
        {
            Hit.MarkForDeath = false;
            PlayBatchMan.Find(BatchName.Ship).Remove(Hit.GetProxy());
            PlayBatchMan.Find(BatchName.Box).Remove(Hit.CollisionObj.Box);
            GameObjectMan.Remove(Hit);
        }
        public override string ToString()
        {
            return "remove Alien";
        }
    }
}
