

namespace SpaceInvaders
{
    public class ProxyMan : ManagerBase
    {
        private static ProxyMan _ProxyManager;
        private  ProxySprite _compareProxy;
        

        private ProxyMan(int t, int d) : base(t, d) { }

        private static ProxyMan GetInstance(int t = 5, int d = 3)
        {
            if (_ProxyManager == null)
            {
                _ProxyManager = new ProxyMan(t, d);
            }
            return _ProxyManager;
        }
        public static void Initialize(int t = 10, int d = 5)
        {
            _ProxyManager = GetInstance(t, d);
        }


        public static ProxySprite Add(GameSpriteName spriteName, float x, float y)
        {
            ProxySprite proxy = new ProxySprite(spriteName, x, y);
            _ProxyManager.AddToFront(proxy);
            return proxy;
        }

        public static ProxySprite Find(GameSpriteName name)
        {
            _ProxyManager._compareProxy.Name = name;
            ProxySprite resultSprite = (ProxySprite)_ProxyManager.BaseFind(_ProxyManager._compareProxy);
            return resultSprite;
        }

        override public bool Compare(DLinkedNode temp)
        {
            GameSprite iTemp = (GameSprite)temp;
            if (iTemp.Name == _compareProxy.Name)
            {
                return true;
            }
            return false;
        }

        public override DLinkedNode CreateNode()
        {
            return new ProxySprite();
        }
    }
}
