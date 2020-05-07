

namespace SpaceInvaders
{
    public class ShieldCol : Composite
    {
        public ShieldCol(int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.Box.SetColor(1, 1, 0, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        public override void Update()
        {
            BaseUpdate();
        }

        //Collision
        public override void Visit(ShipBulletCol b)
        {
            //BulletGroup hit Grid Or Block Collum --> visit children of this
            GameObject ShieldChildren = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(b, ShieldChildren);
        }

        public override void Visit(BombCol b)
        {
            //BombGroup hit Grid Or Block Collum --> visit children of this
            GameObject ShiledChildren = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(b, ShiledChildren);
        }

        public override void Visit(AliensCol b)
        {
            // Alien Hit Shield Group --> visit children of this
            GameObject ShieldChildren = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(b, ShieldChildren);
        }

    }
}


