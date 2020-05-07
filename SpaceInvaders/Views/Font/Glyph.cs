using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Glyph : DLinkedNode
    {
        public GlyphName Name;
        public int key;
        private Azul.Rect rect;
        private Texture texture;

        public Glyph()
        {
            Name = GlyphName.Uninitialized;
            texture = null;
            rect = new Azul.Rect();
            key = 0;
        }

        public Glyph(GlyphName GlyphName, int key, TextureName textName, float x, float y, float width, float height)
        {
            this.Name = GlyphName;
            texture = TextureMan.Find(textName);
            rect = new Azul.Rect(x, y, width, height);
            this.key = key;

        }


        public Azul.Rect GetAzulSubRect()
        {
            return rect;
        }

        public Azul.Texture GetAzulTexture()
        {
            return texture.GetAddress();
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}
