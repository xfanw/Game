using System.Diagnostics;

namespace SpaceInvaders
{
    public class AliensCol : Composite
    {
        public AliensCol(int lx, int ly)
        {
            CollisionObj = new CollisionObject();            
            CollisionObj.Box.SetColor(1, 1, 0, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        // Move X, Y and update
        public override void Update()
        {
            BaseUpdate();
        }
        public override void MoveY()
        {
            y += Nums.AlienDeltaY;
            for (DLinkedNode node = children.GetHead(); node != null; node = node.Next)
            {
                ((GameObject)(Component)node).MoveY();
            }
        }

        //Collision Alien VS bullet
        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }

        public override void Visit(ShipBulletCol b)
        {
            //BulletGroup hit AlienGrid Or Collum --> visit children of this
            GameObject AlienChildren = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(b, AlienChildren);
        }



    }
}
