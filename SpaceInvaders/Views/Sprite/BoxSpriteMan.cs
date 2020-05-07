
namespace SpaceInvaders
{
    public abstract class BoxSpriteMan_Base : ManagerBase {
        public BoxSpriteMan_Base(int t, int d) : base(t, d) { }
    }
    public class BoxSpriteMan : BoxSpriteMan_Base
    {
        private static BoxSpriteMan _boxMan;
        BoxSprite compareSprite = new BoxSprite();
        private BoxSpriteMan(int t, int d) : base(t, d) { }

        private static BoxSpriteMan GetInstance(int t = 10, int d = 5)
        {
            if (_boxMan == null)
            {
                _boxMan = new BoxSpriteMan(t, d);
            }
            return _boxMan;
        }
        public static void Initialize(int t = 10, int d = 5)
        {
            _boxMan = GetInstance(t, d);
        }
        public static BoxSprite Add(BoxSpriteName name, float x, float y, float w, float h, float r, float g, float b, float a)
        {
            BoxSprite s = new BoxSprite(name, x, y, w, h, r, g, b, a);
            _boxMan.AddToFront(s);
            return s;
        }
        public static BoxSprite Add(Azul.Rect rect)
        {
            BoxSprite s = new BoxSprite(rect);
            _boxMan.AddToFront(s);
            return s;
        }
        public static void Remove(BoxSpriteName name)
        {
            BoxSprite temp = Find(name);
            _boxMan.Remove(temp);
        }

        public static BoxSprite Find(BoxSpriteName name)
        {
            _boxMan.compareSprite.Name = name;
            BoxSprite resultSprite = (BoxSprite)_boxMan.BaseFind(_boxMan.compareSprite);
            return resultSprite;
        }

        public override bool Compare(DLinkedNode temp)
        {
            BoxSprite iTemp = (BoxSprite)temp;
            if (iTemp.Name == compareSprite.Name)
            {
                return true;
            }
            return false;
        }

        override public DLinkedNode CreateNode()
        {
            return new BoxSprite();
        }
    }
}
