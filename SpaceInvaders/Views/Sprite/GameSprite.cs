
namespace SpaceInvaders
{
    
    public class GameSprite : SpriteBase
    {
        public GameSpriteName Name;
        public ImageName Image;
        private Azul.Sprite _Sprite;

        public GameSprite()
        {
            Name = GameSpriteName.uninitialized;
        }

        public GameSprite(GameSpriteName name, ImageName img, float x, float y, float w, float h)
        {
            Name = name;
            Image = img;

            Image image = ImageMan.Find(img);
            Texture texture = TextureMan.Find(image.Texture);
            _Sprite = new Azul.Sprite(texture.GetAddress(), image.GetPosition(), new Azul.Rect(x, y, w, h));

            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            xScale = _Sprite.sx;
            yScale = _Sprite.sy;
            angle = _Sprite.angle;
        }

        override public void Update()
        {
            _Sprite.x = x;
            _Sprite.y = y;
            _Sprite.sx = xScale;
            _Sprite.sy = yScale;
            _Sprite.angle = angle;
            _Sprite.Update();
        }

        override public void Render()
        {
            _Sprite.Render();
        }

        public void SwapRect(float x, float y, float w, float h)
        {
            _Sprite.SwapTextureRect(new Azul.Rect(x, y, w, h));
        }
        public void SwapTexture(Texture texture)
        {
            _Sprite.SwapTexture(texture.GetAddress());
        }
        public void SwapImage(Image img)
        {
            _Sprite.SwapTextureRect(img.GetPosition());
        }

        public void SetColor(float r, float g, float b)
        {
            _Sprite.SwapColor(new Azul.Color(r,g,b));
        }
        public override string ToString()
        {
            return Name.ToString();
        }        
    }
}
