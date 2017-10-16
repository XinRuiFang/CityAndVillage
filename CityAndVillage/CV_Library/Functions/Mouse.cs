using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Functions
{
    public class Mouse
    {
        Texture2D texture;
        Color color;
        Rectangle mouseRect;
        int status;
        int animTime;
        int animFrame;
        Vector2 position;




        public Mouse(Texture2D texture)
        {
            this.texture = texture;
            this.color = Color.White;
            mouseRect = new Rectangle(0, 0, Define.UnitOFpixel, Define.UnitOFpixel);
            animTime = 0;
            animFrame = 0;
        }


        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Rectangle MouseRect
        {
            get {
                mouseRect.Y = status * Define.UnitOFpixel;
                mouseRect.X = animFrame * Define.UnitOFpixel;
                return mouseRect;
            }
        }


        public int Status
        {
            get { return status; }
            set { status = value; }
        }


        public int AnimTime
        {
            get { return animTime; }
            set { animTime = value; }
        }

        public int AnimFrame
        {
            get { return animFrame; }
            set { animFrame = value; }
        }


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
