
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AliensGrid : AliensCol
    {
        public AliensGrid(int lx, int ly) : base(lx, ly)
        {
            CollisionObj.Box.SetColor(0, 0.8f, 0.8f, 1);
        }

        public void Shoot()
        {
            AliensCol shootingCol = (AliensCol)Iterator.GetChild(this);
            int size = children.Size();
            int col = Rand.GetNext(1, size);

            if (Iterator.GetSibling(shootingCol) != null)
            {
                for (int i = 0; i < col; i++)
                {
                    shootingCol = (AliensCol)Iterator.GetSibling(shootingCol);
                }
                BombMan.InitializeBomb(shootingCol.x, shootingCol.y - shootingCol.CollisionObj.Rect.height / 2 - 10);
            }
        }
    }
}
