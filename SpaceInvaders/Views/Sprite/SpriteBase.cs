
namespace SpaceInvaders
{
    public abstract class SpriteBase : DLinkedNode
    {
        public float x, y, w, h, xScale, yScale, angle;
        public abstract void Update();
        public abstract void Render();
    }
}
