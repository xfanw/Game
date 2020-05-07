using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipCol : Composite
    {
        public ShipCol(int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.Box.SetColor(1, 1, 0, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        // update and move
        public override void Update()
        {
            BaseUpdate();
        }


        // collision
        public override void Accept(Visitor other)
        {         
            other.Visit(this);
        }

        public override void Visit(BombCol b)
        {
            // Bomb Hit Ship ->Which ship
            GameObject ShipChild = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(b, ShipChild);

        }

    }
}
