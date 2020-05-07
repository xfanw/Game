
namespace SpaceInvaders
{
    public abstract class Txture_Base : DLinkedNode { }
    public class Texture : Txture_Base
    {
        public TextureName Name;
        private Azul.Texture Address;

        public Texture()
        {
            Name = TextureName.uninitialized;
        }

        public Texture(TextureName name, string s)
        {
            Name = name;
            Address = new Azul.Texture(s);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public Azul.Texture GetAddress()
        {
            return Address;
        }
    }
}
