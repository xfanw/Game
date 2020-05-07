
namespace SpaceInvaders
{
    public class ImageNode : DLinkedNode
    {
        public Image ImageItem;

        public ImageNode() { }

        public ImageNode(ImageName name)
        {

            ImageItem = ImageMan.Find(name);
        }


        public override string ToString()
        {
            return ImageItem.ToString();
        }

    }
}