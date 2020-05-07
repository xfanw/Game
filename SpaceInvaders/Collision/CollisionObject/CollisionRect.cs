
namespace SpaceInvaders
{
    public class CollisionRect : Azul.Rect
    {
        public CollisionRect() { }
        public CollisionRect(Azul.Rect pRect) : base(pRect) { }
        public CollisionRect(CollisionRect pRect) : base(pRect) { }
        public bool Intersect(CollisionRect BulletRect)
        {
            bool status = false;

            float Obj_minx = x - width / 2;
            float Obj_maxx = x + width / 2;
            float Obj_miny = y - height / 2;
            float Obj_maxy = y + height / 2;

            float Bullet_minx = BulletRect.x - BulletRect.width / 2;
            float Bullet_maxx = BulletRect.x + BulletRect.width / 2;
            float Bullet_miny = BulletRect.y - BulletRect.height / 2;
            float Bullet_maxy = BulletRect.y + BulletRect.height / 2;

            // Trivial reject
            if ((Bullet_maxx < Obj_minx) || (Bullet_minx > Obj_maxx) || (Bullet_maxy < Obj_miny) || (Bullet_miny > Obj_maxy))
            {
                status = false;
            }
            else
            {
                status = true;
            }


            return status;
        }

        public void Union(CollisionRect rect)
        {

            if (height == 0 && width == 0)
            {
                x = rect.x;
                y = rect.y;
                width = rect.width;
                height = rect.height;
            }
            else
            {
                float minX;
                float minY;
                float maxX;
                float maxY;

                if (x - width / 2 < rect.x - rect.width / 2) { minX = x - width / 2; }
                else { minX = rect.x - rect.width / 2; }

                if ((x + width / 2) > (rect.x + rect.width / 2))
                {
                    maxX = (x + width / 2);
                }
                else
                {
                    maxX = (rect.x + rect.width / 2);
                }

                if ((y + height / 2) > (rect.y + rect.height / 2))
                {
                    maxY = (y + height / 2);
                }
                else
                {
                    maxY = (rect.y + rect.height / 2);
                }

                if (y - height / 2 < rect.y - rect.height / 2) { minY = y - height / 2; }
                else { minY = rect.y - rect.height / 2; }

                width = (maxX - minX);
                height = (maxY - minY);
                x = minX + width / 2;
                y = minY + height / 2;
            }
        }

    }
}