
namespace SpaceInvaders
{
    public class SpriteBaseNode : DLinkedNode
    {
        public SpriteBase SpriteItem;

        public SpriteBaseNode() { }

        public SpriteBaseNode(SpriteBase absSprite)
        {
            SpriteItem = absSprite;
        }

        public override string ToString()
        {
            return SpriteItem.ToString();
        }

        internal void Update()
        {
            SpriteItem.Update();
        }

        internal void Render()
        {
            SpriteItem.Render();
        }
    }
}
