
namespace SpaceInvaders
{
    public abstract class Image_Base : DLinkedNode { }
    public class Image : Image_Base
    {
        public ImageName Name;
        public TextureName Texture;
        private Azul.Rect Position;

        public Image()
        {
            Name = ImageName.uninitialized;
        }
        public Image(ImageName name)
        {
            Name = name;
        }
        public Image(ImageName name, TextureName texture, float x, float y, float w, float h)
        {
            this.Name = name;
            Texture = texture;
            Position = new Azul.Rect(x, y, w, h);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public Azul.Rect GetPosition()
        {
            return Position;
        }
    }
}
