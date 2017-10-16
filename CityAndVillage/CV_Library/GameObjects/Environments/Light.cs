using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Light : GameObject
    {
        public Light()
        {
            this.size = new Point(240, 240);
            this.renderColor = Color.White;
        }
    }
}
