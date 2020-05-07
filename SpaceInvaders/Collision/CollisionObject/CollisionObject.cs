
namespace SpaceInvaders
{
    public class CollisionObject
    {
        public BoxSprite Box;
        public CollisionRect Rect;
        public CollisionObject()
        {
            Rect = new CollisionRect(new Azul.Rect());
            Box = new BoxSprite(new Azul.Rect(1, 1, 1, 1));
        }

        public CollisionObject(ProxySprite pProxySprite)
        {
            Rect = new CollisionRect(pProxySprite.GetRect());
            Box = new BoxSprite(Rect);           
        }

        // Update Collision
        public void UpdatePos(float x, float y)
        {
            Rect.x = x;
            Rect.y = y;
            Box.Set(x, y, Rect.width, Rect.height);
            Box.Update();
        }
        public void UpdateCollisionObject(CollisionRect rect)
        {
            Rect = rect;
            Box.Set(Rect.x, Rect.y , Rect.width, Rect.height);
            Box.Update();
        }
    }
}