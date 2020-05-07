
namespace SpaceInvaders
{
    public class TextureFactory
    {
        public static Texture CreateConsoles()
        {
            return new Texture(TextureName.Consolas, "Consolas36pt.tga");
        }
        public static Texture CreateInvader4()
        {
            return new Texture(TextureName.Invader_4, "Invaders_4.tga");
        }

        public static Texture CreateInvader3()
        {
            return new Texture(TextureName.Invader_3, "Invaders_3.tga");
        }
    }

}
