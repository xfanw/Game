using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Font: DLinkedNode
    {
        public FontName name;
        public FontSprite fontSprite;


        public Font()
        {
            name = FontName.Uninitialized;
            fontSprite = new FontSprite();
        }

        public void UpdateMessage(string pMessage)
        {
            fontSprite.UpdateMessage(pMessage);
        }

        public Font(FontName name, string pMessage, GlyphName glyphName, float xStart, float yStart)
        {
            this.name = name;
            fontSprite = new FontSprite(name, pMessage, glyphName, xStart, yStart);
        }
        public Font(string pMessage, GlyphName glyphName, float xStart, float yStart)
        {

            fontSprite = new FontSprite(pMessage, glyphName, xStart, yStart);
        }
        public override string ToString()
        {
            return fontSprite.ToString();
        }
    }
}
