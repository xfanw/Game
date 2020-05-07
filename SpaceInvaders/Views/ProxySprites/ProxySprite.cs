
using System;

namespace SpaceInvaders
{
    public class ProxySprite : SpriteBase
    {
        private GameSprite _sprite;
        public GameSpriteName Name;

        public ProxySprite() { }
        public ProxySprite(GameSpriteName name, float x, float y)
        {
            _sprite = GameSpriteMan.Find(name);
            Name = name;
            this.x = x;
            this.y = y;
            w = _sprite.w;
            h = _sprite.h;
            xScale = _sprite.xScale;
            yScale = _sprite.yScale;
        }

        public Azul.Rect GetRect()
        {
            return new Azul.Rect(x, y, w, h);
        }

        private void PushToReal()
        {
            _sprite.x = x;
            _sprite.y = y;
            _sprite.xScale = xScale;
            _sprite.yScale = yScale;
        }
        public override void Update()
        {
        }

        public override void Render()
        {
            PushToReal();
            _sprite.Update();
            _sprite.Render();
        }

        public override string ToString()
        {
            return "Proxy";
        }

        public void Set(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public GameSprite GetSprite()
        {
            return _sprite;
        }
    }
}
