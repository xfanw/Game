

namespace SpaceInvaders
{
    public class ShieldGrid : ShieldBlock
    {
        public ShieldGrid(int lx, int ly) : base(lx, ly)
        {
            CollisionObj.Box.SetColor(1, 0, 0, 1);
        }

        //for Bug of deleting Bricks
        //public override void Visit(AliensGrid b)
        //{
        //    // Alien Hit Shield Grid --> visit children of this
        //    GameObject ShieldChildren = (GameObject)Iterator.GetChild(this);
        //    CollisionPair.Collide(b, ShieldChildren);
        //}
    }
}
