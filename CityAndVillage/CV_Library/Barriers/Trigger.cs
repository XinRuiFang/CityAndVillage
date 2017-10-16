using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Trigger
    {
        Rectangle collider;
        int index;



        public Trigger(int x, int y, int width, int height,int index)
        {
            this.collider = new Rectangle(x * Define.UnitOFpixel, y * Define.UnitOFpixel, width * Define.UnitOFpixel, height * Define.UnitOFpixel);
            this.index = index;
        }

        public Rectangle Collider
        {
            get { return collider; }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}
