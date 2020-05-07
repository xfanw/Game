

namespace SpaceInvaders
{
    public class AlienLeaf : Leaf
    {      
        
        public AlienLeaf(GameSpriteName spname, float x, float y, int lx, int ly)
        {
            proxySprite = new ProxySprite(spname, x, y);
            CollisionObj = new CollisionObject(proxySprite);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);

            this.x = x;
            this.y = y;
            locationX = lx;
            locationY = ly;

        } 

        override public string ToString()
        {
           return "Alien Leaf";
        }

        //Move X, Y and Update
        override public void MoveY() { y += Nums.AlienDeltaY; }

        override public void MoveX() { x += Nums.AlienDeltaX; }

        public override void Update()
        {
            MoveX();        
            proxySprite.Set(x, y);
            CollisionObj.UpdatePos(x, y);
        }
        // Collisions 
        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }
        public override void Visit(ShipBulletCol a)
        {
            GameObject BulletChildren = (GameObject)Iterator.GetChild(a);
            CollisionPair.Collide(BulletChildren, this);
        }
        public override void Visit(ShipBulletLeaf a)
        {
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Alien_Bullet);
            pair.SetCollision(a, this);
            pair.Notify();
        }
    }
}
