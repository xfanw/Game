using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FontSprite : SpriteBase
    {
        public FontName name;
        private Azul.Sprite AzulSprite;
        private Azul.Rect AzulRect;
        private Azul.Color pColor;   // this color is multplied by the texture

        private string Message;
        public GlyphName glyphName;

        public GlyphName GetGlyphName()
        {
            return glyphName;
        }


        public FontSprite()
        {
            AzulSprite = new Azul.Sprite();
            AzulRect = new Azul.Rect();
            pColor = new Azul.Color(1.0f, 1.0f, 1.0f);
            Message = null;
            glyphName = GlyphName.Uninitialized;
            x = 0.0f;
            y = 0.0f;

        }


        public FontSprite(FontName name, string msg, GlyphName glyphName, float xStart, float yStart)
        {
            Message = msg;
            x = xStart;
            y = yStart;

            this.name = name;
            this.glyphName = glyphName;

            pColor = new Azul.Color(1.0f, 1.0f, 1.0f);
        }

        public FontSprite(string msg, GlyphName glyphName, float xStart, float yStart)
        {
            Message = msg;
            x = xStart;
            y = yStart;
            this.glyphName = glyphName;

            pColor = new Azul.Color(1.0f, 1.0f, 1.0f);
        }

        public void SetColor(float red, float green, float blue, float alpha = 1.0f)
        {
            pColor.Set(red, green, blue, alpha);
        }

        public void UpdateMessage(string msg)
        {
            Message = msg;
        }

        override public void Update()
        {

        }

        override public void Render()
        {

            float xTmp = x;
            float yTmp = y;

            float xEnd = x;

            for (int i = 0; i < Message.Length; i++)
            {
                int key = Convert.ToByte(Message[i]);

                Glyph pGlyph = GlyphMan.Find(glyphName, key);

                xTmp = xEnd + pGlyph.GetAzulSubRect().width / 2;
                AzulRect = new Azul.Rect(xTmp, yTmp, pGlyph.GetAzulSubRect().width / 2, pGlyph.GetAzulSubRect().height / 2);

                AzulSprite = new Azul.Sprite(pGlyph.GetAzulTexture(), pGlyph.GetAzulSubRect(), AzulRect, pColor);

                AzulSprite.Update();
                AzulSprite.Render();

                xEnd = pGlyph.GetAzulSubRect().width / 4 + xTmp;

            }
        }

        public override string ToString()
        {
            return name.ToString();
        }
    }
}