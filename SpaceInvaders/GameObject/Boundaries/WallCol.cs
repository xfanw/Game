using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallCol : Composite
    {
        public WallCol(int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.Box.SetColor(1, 1, 0, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        // Update
        public override void Update() { BaseUpdate(); }
        public override string ToString() { return name; }

        //Collision
        public override void Visit(AliensCol a)
        {
            //AlienGrid Hit WallGroup ---> detect wich wall
            GameObject WallChildren = (GameObject)GetFirstChild();
            CollisionPair.Collide(a, (GameObject)GetFirstChild());
        }
        public override void Visit(ShipBulletCol a)
        {
            //Bullet Hit WallGroup ---> detect wich wall
            GameObject WallChildren = (GameObject)GetFirstChild();
            CollisionPair.Collide(a, WallChildren);
        }
        public override void Visit(UFOCol a)
        {
            //AlienGrid Hit WallGroup ---> detect wich wall
            GameObject WallChildren = (GameObject)GetFirstChild();
            CollisionPair.Collide(a, WallChildren);
        }

        public override void Visit(BombCol a)
        {
            //Bomb Hit WallGroup ---> detect wich wall
            GameObject WallChildren = (GameObject)GetFirstChild();
            CollisionPair.Collide(a, WallChildren);
        }

    }
}
