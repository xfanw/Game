using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldBrick : Leaf
    {
        public ShieldBrick(GameSpriteName spname, float x, float y, int lx, int ly)
        {
            proxySprite = new ProxySprite(spname, x, y);
            CollisionObj = new CollisionObject(proxySprite);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);

            // set obj Green
            proxySprite.GetSprite().SetColor(0, 1, 0);
            this.x = x;
            this.y = y;
            locationX = lx;
            locationY = ly;

        }
        public override string ToString()
        {
            return "Bumper Leaf" + locationX + "." + locationY;
        }

        // Collisions  

        // Bullet Hit Shield
        public override void Visit(ShipBulletCol b)
        {
            // Bullet Hit Shield Brick --> visit children of Bullets
            GameObject BulletChild = (GameObject)Iterator.GetChild(b);
            CollisionPair.Collide(BulletChild, this);
        }
        public override void Visit(ShipBulletLeaf b)
        {
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Bullet_Shield);
            pair.SetCollision(b, this);
            pair.Notify();
        }

        // Bomb Hit Shield
        public override void Visit(BombCol b)
        {
            // Bomb Hit Shield Brick --> visit children of Bombs
            GameObject BombChild = (GameObject)Iterator.GetChild(b);
            CollisionPair.Collide(BombChild, this);
        }
        public override void Visit(BombLeaf b)
        {
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Bomb_Shield);
            pair.SetCollision(b, this);
            pair.Notify();
        }

        // Alien Hit Shield
        public override void Visit(AliensCol b)
        {
            // Alien Hit Shield Brick --> visit children of Aliens
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Alien_Shield);
            pair.SetCollision(b, this);
            pair.Notify();
        }
    }
}

