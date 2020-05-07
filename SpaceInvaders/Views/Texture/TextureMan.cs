using System;

namespace SpaceInvaders
{
    public abstract class TxtureMan_Base : ManagerBase
    {
        public TxtureMan_Base(int t, int d) : base(t, d) { }
    }
    public class TextureMan : TxtureMan_Base
    {
        private static TextureMan _textureMan;
        private Texture compareTexture = new Texture();

        public static void Initialize(int t = 4, int d = 1)
        {
            _textureMan = GetInstance(t, d);
            //AddAll();
        }

        private TextureMan(int t, int d) : base(t, d) { }

        private static TextureMan GetInstance(int t, int d)
        {
            if (_textureMan == null)
            {
                _textureMan = new TextureMan(t, d);
            }
            return _textureMan;
        }

        public static Texture Add(Texture texture)
        {
            
            _textureMan.AddToFront(texture);
            return texture;
        }

        //Find and compare are used for getting an object in the active list.
        public static Texture Find(TextureName name)
        {
            _textureMan.compareTexture.Name = name;
            Texture resultTexture = (Texture)_textureMan.BaseFind(_textureMan.compareTexture);
            return resultTexture;
        }

        public static void Remove(TextureName name)
        {
            Texture temp = Find(name);
            _textureMan.Remove(temp);
        }
        public override bool Compare(DLinkedNode temp)
        {
            if (((Texture)temp).Name == compareTexture.Name)
            {
                return true;
            }
            return false;
        }

        public override DLinkedNode CreateNode()
        {
            return new Texture();
        }

        internal static void AddAll()
        {
            Add(TextureFactory.CreateConsoles());
            Add(TextureFactory.CreateInvader4());
            Add(TextureFactory.CreateInvader3());
        }
    }
}
