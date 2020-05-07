

namespace SpaceInvaders
{
    public class UFOLeaf : Leaf
    {
        public UFOLeaf()
        {
            name = "uninitialized";
        }
        public UFOLeaf(GameSpriteName spname, float x, float y, int lx, int ly)
        {
            proxySprite = new ProxySprite(spname, x, y);
            CollisionObj = new CollisionObject(proxySprite);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            proxySprite.GetSprite().SetColor(0.8f, 0, 0);
            this.x = x;
            this.y = y;
            locationX = lx;
            locationY = ly;
            name = "UFO Leaf";

        }


        public void SetPos(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        override public string ToString()
        {
            return name;
        }

        //Move X, Y and Update
        override public void MoveX() { x += Nums.UFOSpeed; }

        public override void Update()
        {                
            proxySprite.Set(x, y);
            CollisionObj.UpdatePos(x, y);
        }

        // Collisions 
        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }
        public override void Visit(ShipBulletCol b)
        {
            GameObject BulletChildren = (GameObject)Iterator.GetChild(b);
            CollisionPair.Collide(BulletChildren, this);
        }
        public override void Visit(ShipBulletLeaf b)
        {
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Bullet_UFO);
            pair.SetCollision(b, this);
            pair.Notify();
            Score.Add(Rand.GetNext(50, 100));
        }
    }
}
