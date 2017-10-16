using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Globals
{
    public class UIFrame
    {
        Point frame;
        Vector2 pos;
        Rectangle rect;
        float layerDepth;
        Color color;

        public UIFrame(Point frame, Vector2 pos, Rectangle rect, float layerDepth, Color color)
        {
            this.frame = frame;
            this.pos = pos;
            this.rect = rect;
            this.layerDepth = layerDepth;
            this.color = color;
        }

        public Point Frame
        {
            set { frame = value; }
            get { return frame; }
        }

        public Vector2 Pos
        {
            set { pos = value; }
            get { return pos; }
        }

        public Rectangle Rect
        {
            get 
            {
                rect.X = Frame.X * Define.UnitOFpixel;
                rect.Y = Frame.Y * Define.UnitOFpixel;
                return rect; 
            }
        }


        public float LayerDepth
        {
            get { return layerDepth; }
        }


        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
