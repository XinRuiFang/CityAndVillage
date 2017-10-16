using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Flower : GameObject, IGlobalScene
    {
        Point currentFrame;
        Point sheetSize;
        int animTime;
        int nowAnimTime;


        public Flower(Map map, Texture2D texture, Vector2 position,int animTime)
        {
            this.map = map;
            this.texture = texture;
            this.position = new Vector2(position.X * Define.UnitOFpixel, position.Y * Define.UnitOFpixel);

            this.size = new Point(1, 1);
            this.scale = 1;

            currentFrame = new Point(5, 1);
            this.animTime = animTime;
            nowAnimTime = 0;

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
        }

        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Point SheetSize
        {
            get { return sheetSize; }
            set { sheetSize = value; }
        }

        public Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = currentFrame.X * Define.UnitOFpixel;
                renderRectangle.Y = currentFrame.Y * Define.UnitOFpixel;
                return renderRectangle;
            }
        }
        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(this.position, GlobalController.Camera); }
        }
        public float LayerDepth
        {
            get
            {
                return 0.1f;
            }
        }

        public int AnimTime
        {
            get { return animTime; }
        }

        public int NowAnimTime
        {
            get { return nowAnimTime; }
            set { nowAnimTime = value; }
        }
        public string GetMap()
        {
            return this.Map.Name;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
        }

        public Rectangle GetCollider()
        {
            return this.Collider;
        }

        public GameObject GetInstance()
        {
            return this;
        }

        public string GetIntanceType()
        {
            return "Flower";
        }
    }
}
