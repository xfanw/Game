
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Batch : SDLinkedNode
    {
        private int Priority;
        public BatchName Name;
        private BaseNodeMan iMan = new BaseNodeMan(4, 2);
        private bool visible = true;
        public Batch() { }
        public Batch(BatchName name, int p)
        {
            Name = name;
            Priority = p;
        }

        public void Add(SpriteBase bSprite)
        {
            iMan.Add(bSprite);
        }

        public void Remove(SpriteBase bSprite)
        {
            iMan.Remove(bSprite);
        }

        public override string ToString()
        {
            string details = Name.ToString() + "\tPriority: " + Priority.ToString() + "\nSprites in this group:";
            for (DLinkedNode item = iMan.GetActive().GetHead(); item != null; item = item.Next)
            {
                details += "\n" + ((SpriteBaseNode)item).ToString();
            }
            Debug.WriteLine(details);
            return details;
        }

        // update and render Sprites in group
        public void Update()
        {
            if (iMan.GetActive().GetHead() != null)
            {
                for (DLinkedNode item = iMan.GetActive().GetHead(); item != null; item = item.Next)
                {
                    ((SpriteBaseNode)item).Update();
                }
            }
        }
        public void Render()
        {
            if (iMan.GetActive().GetHead() != null)
            {
                if (visible == true)
                {
                    for (DLinkedNode item = iMan.GetActive().GetHead(); item != null; item = item.Next)
                    {
                        ((SpriteBaseNode)item).Render();
                    }
                }
            }
        }
        // change visibility
        public void SetVisible(bool v)
        {
            visible = v;
        }
        public bool GetVisible()
        {
            return visible;
        }

        // override compare
        public override bool LargerThan(SDLinkedNode b)
        {
            return Priority > ((Batch)b).Priority;
        }

        public override bool SmallerThan(SDLinkedNode b)
        {
            return Priority < ((Batch)b).Priority;
        }

        public override bool EqualTo(SDLinkedNode b)
        {
            return Priority == ((Batch)b).Priority;
        }
    }
}
