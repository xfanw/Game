using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumperLeaf : Leaf
    {

        public BumperLeaf(int x, int y, int w, int h, int lx, int ly)
        {
            CollisionObj = new CollisionObject();
            CollisionObj.UpdateCollisionObject(new CollisionRect(new Azul.Rect(x, y, w, h)));
            CollisionObj.Box.SetColor(1, 1, 1, 1);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            locationX = lx;
            locationY = ly;
        }

        public override string ToString()
        {
            return "Bumper Leaf" + locationX + "." +locationY ;
        }

        public override void Visit(ShipCol a)
        {
            GameObject Ship = (GameObject)Iterator.GetChild(a);
            CollisionPair.Collide(Ship,this);
        }

        public override void Visit(ShipLeaf b)
        {
            if (locationY == 201)  //hit left
            {                
                ShipMan.GetShip().x += Nums.ShipSpeed;
            }
            else   //hit right
            {
                ShipMan.GetShip().x -= Nums.ShipSpeed;
            }
        }

    }
}
