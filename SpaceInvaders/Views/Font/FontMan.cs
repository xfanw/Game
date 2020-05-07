using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    class FontMan : ManagerBase
    {
        private static FontMan _FontMan = null;
        private Font CompareFont = new Font();
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public static void Initialize(int t = 4, int d = 1)
        {
            _FontMan = GetInstance(t, d);
        }

        private FontMan(int t, int d) : base(t, d) { }

        private static FontMan GetInstance(int t, int d)
        {
            if (_FontMan == null)
            {
                _FontMan = new FontMan(t, d);
            }
            return _FontMan;
        }

        public static Font Add(FontName name, Batch batch, string Message, float xStart, float yStart)
        {

            Font tempFont = new Font(name, Message, GlyphName.Consolas36pt, xStart, yStart);
            batch.Add(tempFont.fontSprite);
            _FontMan.AddToFront(tempFont);
            return tempFont;
        }
        public static Font Add(Batch batch, string Message, float xStart, float yStart)
        {

            Font tempFont = new Font(Message, GlyphName.Consolas36pt, xStart, yStart);
            batch.Add(tempFont.fontSprite);
            _FontMan.AddToFront(tempFont);
            return tempFont;
        }
        public static void AddXml(GlyphName glyphName, string assetName, TextureName textName)
        {
            GlyphMan.AddXml(glyphName, assetName, textName);
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            _FontMan.Remove((DLinkedNode)pNode);
        }
        public static Font Find(FontName name)
        {
            _FontMan.CompareFont.name = name;
            Font result = (Font)_FontMan.BaseFind(_FontMan.CompareFont);
            return result;
        }

        public override bool Compare(DLinkedNode temp)
        {
            if (((Font)temp).name == CompareFont.name)
            {
                return true;
            }
            return false;
        }

        public override DLinkedNode CreateNode()
        {
            return new Font();
        }
    }
}
