using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallLeaf : Leaf
    {
        public WallLeaf(int x, int y, int w, int h, int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.UpdateCollisionObject(new CollisionRect(new Azul.Rect(x, y, w, h)));
            CollisionObj.Box.SetColor(1, 1, 1, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        public override string ToString() { return "Wall Leaf"; }

        // Collision
        public override void Visit(AliensCol a)
        {
            // Alien Col hit Wall -> change direction
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Alien_Wall);
            pair.Notify();
            Nums.AlienDeltaX *= -1;
        }
        public override void Visit(ShipBulletCol a)
        {
            //Bullet Hit WallLeaf ---> Which Bullet
            GameObject BulletChild = (GameObject)Iterator.GetChild(a);
            CollisionPair.Collide(BulletChild, this);
        }
        public override void Visit(ShipBulletLeaf a)
        {
            //Bullet Hit WallLeaf ---> reset 
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Bullet_Wall);
            pair.SetCollision(a, this);
            pair.Notify();
        }
        public override void Visit(UFOCol a)
        {
            //UFO Hit WallLeaf ---> Which UFO
            GameObject UFOChild = (GameObject)Iterator.GetChild(a);
            CollisionPair.Collide(UFOChild, this);

        }
        public override void Visit(UFOLeaf a)
        {
            CollisionPair pair = ColPairMan.Find(CollisionPairName.UFO_Wall);
            pair.SetCollision(this, a);
            pair.Notify();
        }

        public override void Visit(BombCol a)
        {
            //Bomb Hit WallLeaf ---> Which Bomb
            GameObject BombChild = (GameObject)Iterator.GetChild(a);
            CollisionPair.Collide(BombChild, this);
        }
        public override void Visit(BombLeaf a)
        {
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Bomb_Wall);
            pair.SetCollision(a, this);
            pair.Notify();
        }



    }
}
