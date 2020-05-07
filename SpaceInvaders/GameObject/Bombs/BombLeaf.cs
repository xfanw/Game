
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombLeaf : Leaf
    {
        private FallStrategy _Strategy;

        public BombLeaf(GameSpriteName spname, FallStrategy strategy, float x, float y, int lx, int ly)
        {
            proxySprite = new ProxySprite(spname, x, y);
            CollisionObj = new CollisionObject(proxySprite);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            this.x = x;
            this.y = y;
            _Strategy = strategy;
            _Strategy.Reset(this.y);
        }

        public override void Update()
        {
            MoveY();
            // Strategy
            _Strategy.Fall(this);

            proxySprite.Set(x, y);
            CollisionObj.UpdatePos(x, y);
        }

        public void ResetStrategy()
        {
            _Strategy.Reset(this.y);
        }
        public override void MoveY()
        {
            y -= Nums.BombSpeed;

        }
        public float GetHeight()
        {
            return GetProxy().h;
        }

        public void SetPos(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public void MultiplyScale(float sx, float sy)
        {
            GetProxy().xScale *= sx;
            GetProxy().yScale *= sy;
        }

        public override string ToString()
        {
            return "Bomb Leaf";
        }

        //collisions
        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }

        public override void Visit(ShipBulletCol b)
        {
            //BulletGroup hit Bomb --> visit children of Bullet
            GameObject BulletChild = (GameObject)Iterator.GetChild(b);
            CollisionPair.Collide(BulletChild, this);
        }

        public override void Visit(ShipBulletLeaf b)
        {
            //Bullet hit Bullet --> Do Something
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Bullet_Bomb);
            pair.SetCollision(b,this);
            pair.Notify();
        }
    }
}

// End of File
