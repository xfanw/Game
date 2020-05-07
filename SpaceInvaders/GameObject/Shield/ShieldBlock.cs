
namespace SpaceInvaders
{
    public class ShieldBlock : ShieldCol
    {
        public ShieldBlock(int lx, int ly) : base(lx, ly)
        {
            CollisionObj.Box.SetColor(0, 0.8f, 0.8f, 1);
        }

        //for Bug of deleting Bricks
        //public override void Visit(AliensGrid b)
        //{
        //    // AlienGrid Hit Shield Block --> visit children of Alien
        //    GameObject AlienChild = (GameObject)Iterator.GetChild(b);
        //    CollisionPair.Collide(AlienChild, this);
        //}

        //public override void Visit(AliensCol b)
        //{
        //    // AlienCol Hit Shield Block --> visit children of Shield
        //    GameObject ShieldChild = (GameObject)Iterator.GetChild(this);
        //    CollisionPair.Collide(b, ShieldChild);
        //}
    }
}

// End of File
