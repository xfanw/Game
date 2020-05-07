
namespace SpaceInvaders
{
    
    public class BoxSprite : SpriteBase
    {
        private Azul.SpriteBox Box;
        private Azul.Rect rect;
        private Azul.Color color;
        public BoxSpriteName Name;
        

        public BoxSprite()
        {
            Name = BoxSpriteName.uninitialized;
        }

        public BoxSprite(BoxSpriteName name, float x, float y, float w, float h, float r, float g, float b, float a)
        {
            Name = name;
            rect = new Azul.Rect(x, y, w, h);
            color = new Azul.Color(r, g, b, a);
            Box = new Azul.SpriteBox(rect, color);
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            angle = Box.angle;
            xScale = Box.sx;
            yScale = Box.sy;
        }

        public BoxSprite(Azul.Rect rect)
        {
            Name = BoxSpriteName.Box;
            this.rect = rect;
            color = new Azul.Color(1f, 0.5f, 1f, 1);
            Box = new Azul.SpriteBox(rect, color);
            x = Box.x;
            y = Box.y;
            w = rect.width;
            h = rect.height;
            angle = Box.angle;
            xScale = Box.sx;
            yScale = Box.sy;
        }
        public void SetColor(float r, float g, float b, float a)
        {
            color = new Azul.Color(r, g, b, a);
            Box.SwapColor(color);
        }
        public void Set(float x, float y, float w, float h)
        {
            rect.Set(x, y, w, h);
            Box.Swap(rect, color);
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            angle = Box.angle;
            xScale = Box.sx;
            yScale = Box.sy;

        }
        public override void Render()
        {
            Box.Render();
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public override void Update()
        {
            Box.Update();
        }
    }
}
