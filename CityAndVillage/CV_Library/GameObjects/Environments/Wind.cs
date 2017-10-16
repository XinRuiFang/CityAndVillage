using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Wind : Weather
    {
        Point currentFrame;
        Point sheetSize;
        bool endMoving;
        int timeFrame;
        bool end;

        public bool End
        {
            get { return end; }
            set { end = value; }
        }

        public bool EndMoving
        {
            get { return endMoving; }
            set { endMoving = value; }
        }

        public Wind(Texture2D texture, Vector2 position,float scale)
        {
            this.texture = texture;
            this.position = position;
            this.currentFrame = new Point(0, 0);
            this.sheetSize = new Point(16, 40);
            this.size = new Point(16, 8);
            this.endMoving = false;
            this.scale = scale;
            end = false;
            timeFrame = 0;

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
            this.renderColor = Color.White;
        }



        public void Anim(int time)
        {
            timeFrame += time;
            if (timeFrame > 80)
            {
                this.currentFrame.Y += 8;
                timeFrame = 0;
                if (this.currentFrame.Y >= 40)
                {
                    end = true;
                }

            }

        }

        public Rectangle RenderRectangle
        {
            get
            {
                this.renderRectangle.X = currentFrame.X * Define.UnitOFpixel;
                this.renderRectangle.Y = currentFrame.Y * Define.UnitOFpixel;
                return renderRectangle;
            }
        }

        public Vector2 RenderPosition
        {
            get
            {
                return this.position;
            }
        }
    }
}
