using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GlyphMan : ManagerBase
    {

        private static GlyphMan _GlyphMan = null;
        private Glyph CompareGlyph = new Glyph();

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public static void Initialize(int t = 4, int d = 1)
        {
            _GlyphMan = GetInstance(t, d);
        }

        private GlyphMan(int t, int d) : base(t, d) { }

        private static GlyphMan GetInstance(int t, int d)
        {
            if (_GlyphMan == null)
            {
                _GlyphMan = new GlyphMan(t, d);
            }
            return _GlyphMan;
        }

        //----------------------------------------------------------------------
        // Static Manager methods can be implemented with base methods 
        // Can implement/specialize more or less methods your choice
        //----------------------------------------------------------------------
        public static Glyph Add(GlyphName name, int key, TextureName textName, float x, float y, float width, float height)
        {
            Glyph glyph = new Glyph(name, key, textName, x,y,width,height);
            _GlyphMan.AddToFront(glyph);
            return glyph;
        }

        public static void AddXml(GlyphName glyphName, string assetName, TextureName textName)
        {
            XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            // I'm sure there is a better way to do this... but this works for now
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element 
                        if (reader.Name == "character")
                        {
                            Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }
        }

        public static void Remove(Glyph glyph)
        {
            _GlyphMan.Remove((DLinkedNode)glyph);
        }
        public static Glyph Find(GlyphName name, int key)
        {
            _GlyphMan.CompareGlyph.Name = name;
            _GlyphMan.CompareGlyph.key = key;

            Glyph result = (Glyph)_GlyphMan.BaseFind(_GlyphMan.CompareGlyph);
            return result;
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        public override bool Compare(DLinkedNode temp)
        {
            if (((Glyph)temp).Name == CompareGlyph.Name && ((Glyph)temp).key == CompareGlyph.key)
            {
                return true;
            }
            return false;
        }

        public override DLinkedNode CreateNode()
        {
            return new Glyph();
        }      

    }
}
