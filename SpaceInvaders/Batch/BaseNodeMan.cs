
using System;

namespace SpaceInvaders
{
    public class BaseNodeMan : ManagerBase
    {
        private SpriteBaseNode compareItem = new SpriteBaseNode();

        public BaseNodeMan(int t, int d) : base(t, d) { }      

        public SpriteBaseNode Add(SpriteBase baseSprite)
        {
            SpriteBaseNode item = new SpriteBaseNode(baseSprite);
            AddToFront(item);
            return item;
        }


        public void Remove(SpriteBase baseSprite)
        {
            SpriteBaseNode iTemp = Find(baseSprite);
            Remove(iTemp);            
        }
        public SpriteBaseNode Find(SpriteBase spBase)
        {
            compareItem.SpriteItem = spBase;
            SpriteBaseNode resultItem = (SpriteBaseNode)BaseFind(compareItem);

            return resultItem;
        }
        public override bool Compare(DLinkedNode temp)
        {
            SpriteBaseNode iTemp = (SpriteBaseNode)temp;
            if (iTemp.SpriteItem == compareItem.SpriteItem)
            {
                return true;
            }
            return false;
        }

        public override DLinkedNode CreateNode()
        {
            return new GameSprite();
        }
    }
}
