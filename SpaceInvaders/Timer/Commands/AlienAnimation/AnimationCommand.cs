
namespace SpaceInvaders
{
    public class AnimationCommand : CommandBase
    {
        private DLinkedList ImageItems = new DLinkedList();
        private GameSprite AnimationSprite;
        private DLinkedNode pointer;
        public AnimationName Name;
        public AnimationCommand()
        {
            Name = AnimationName.uninitialized;
        }
        public AnimationCommand(AnimationName Aname, GameSpriteName sprite)
        {
            AnimationSprite = GameSpriteMan.Find(sprite);
            Name = Aname;
        }
        public void AddImage(ImageName name)
        {
            ImageItems.Add(new ImageNode(name));
        }
        public override void Run()
        {
            if (pointer == null)
            {
                pointer = ImageItems.GetHead();
            }
            else
            {
                pointer = pointer.Next;
                if (pointer == null)
                {
                    pointer = ImageItems.GetHead();
                }
            }
            AnimationSprite.SwapImage(((ImageNode)pointer).ImageItem);
        }

        public override string ToString()
        {
            return "Annimation Command: " + Name;
        }


    }
}
