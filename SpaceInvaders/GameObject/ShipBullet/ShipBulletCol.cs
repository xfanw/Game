
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipBulletCol : Composite
    {
        public ShipBulletCol(int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.Box.SetColor(1, 1, 0, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        // Collision detection
        public override void Accept(Visitor other) {
            other.Visit(this);
        }

        public override void Update()
        {
            BaseUpdate();
        }
    }
}
