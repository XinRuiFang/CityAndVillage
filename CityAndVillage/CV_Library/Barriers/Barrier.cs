using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Barrier
    {
        Rectangle collider;

        public Barrier(int x,int y,int width,int height)
        {
            this.collider = new Rectangle(x * Define.UnitOFpixel, (y + 1) * Define.UnitOFpixel, width * Define.UnitOFpixel, height * Define.UnitOFpixel);
        }

        public Rectangle Collider
        {
            get { return collider; }
        }
    }
}
