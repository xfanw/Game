namespace SpaceInvaders
{
    public class BombCol : Composite
    {
        public BombCol(int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.Box.SetColor(1, 1, 0, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        // Move X, Y and update
        public override void Update()
        {
            BaseUpdate();
        }
        public override void MoveY()
        {

        }
        public override void MoveX() { }



        //Collision 
        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }

        public override void Visit(ShipBulletCol b)
        {
            //BombGroup hit Bullet --> visit children of this
            GameObject BombChild = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(b, BombChild);
        }



    }
}
