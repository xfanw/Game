using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOCol : Composite
    {
        public UFOCol(int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.Box.SetColor(1, 1, 0, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        // Update
        public override void Update()
        {
            BaseUpdate();
        }

        // Collision
        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }
        public override void Visit(ShipBulletCol b)
        {
            //BulletGroup hit UFOGrid --> visit children of this
            GameObject UFO = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(b, UFO);
        }


    }
}
