using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Rain : Weather
    {
        Point currentFrame;
        Point sheetSize;
        Vector2 endPosition;
        int speed;
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

        public Rain(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            this.currentFrame = new Point(0, 0);
            this.sheetSize = new Point(16, 4);
            this.size = new Point(4, 4);
            this.speed = 9;
            this.endMoving = false;
            this.scale = 0.75f;
            end = false;
            timeFrame = 250;
            FindTarget(position);

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
            this.renderColor = Color.White;
        }

        void FindTarget(Vector2 position)
        {
            int y = 500;
            endPosition = new Vector2(position.X, position.Y + y);
        }
        public void Move()
        {
            this.position.Y += speed;
            if (this.position.Y > endPosition.Y)
            {
                endMoving = true;
            }
        }

        public void Anim(int time)
        {
            timeFrame += time;
            if (timeFrame > 80)
            {
                timeFrame = 0;
                this.currentFrame.X += 4;
                if (this.currentFrame.X > 12)
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
