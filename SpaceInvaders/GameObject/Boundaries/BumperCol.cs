using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumperCol : Composite
    {
        public BumperCol(int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.Box.SetColor(1, 1, 0, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }
        public override string ToString()
        {
            return name;
        }

        public override void Update()
        {
            BaseUpdate();
        }

        //Collisions
        public override void Visit(ShipCol a)
        {
            GameObject BumpChild = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(a, BumpChild);
        }

        public override void Visit(AliensCol a)
        {
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Alien_Bump);
            pair.Notify();
        }
    }
}
