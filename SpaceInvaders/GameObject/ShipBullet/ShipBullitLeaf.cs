
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipBulletLeaf : Leaf
    {
        public bool Boom = false;

        public ShipBulletLeaf(GameSpriteName spname, float x, float y, int lx, int ly)
        {
            proxySprite = new ProxySprite(spname, x, y);
            CollisionObj = new CollisionObject(proxySprite);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            this.x = x;
            this.y = y;
            locationX = lx;
            locationY = ly;
        }


        // Move X = null; Move Y and update
        public override void MoveY()
        {
            y += Nums.ShipBulletSpeed;
        }

        public override void Update()
        {
            MoveY();
            proxySprite.Set(x, y);
            CollisionObj.UpdatePos(x, y);
        }
        public void SetPos(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "Bullet Leaf: " + locationX + "." + locationY;
        }

        //Collision detection
        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }
    }
}
