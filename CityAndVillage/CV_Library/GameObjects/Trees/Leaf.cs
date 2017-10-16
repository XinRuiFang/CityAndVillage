using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Trees
{
    public class Leaf : GameObject,IGlobalScene
    {
        Point currentFrame;
        float disappear;

        public Leaf(Texture2D texture,Map map,Vector2 position,int type,float disappear,float scale)
        {
            this.map = map;
            this.position = position;
            this.texture = texture;
            this.disappear = disappear;
            switch (type)
            {
                case 1:
                    currentFrame = new Point(25, 0);
                    break;
                case 2:
                    currentFrame = new Point(26, 0);
                    break;
                case 3:
                    currentFrame = new Point(27, 0);
                    break;
                case 4:
                    currentFrame = new Point(28, 0);
                    break;
                case 5:
                    currentFrame = new Point(29, 0);
                    break;
                case 6:
                    currentFrame = new Point(25, 1);
                    break;
                default:
                    break;
            }

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel,  Define.UnitOFpixel, Define.UnitOFpixel);
            Random ran = new Random();
            this.rotation = (float)ran.NextDouble();
            this.scale = scale;
        }

        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        public string GetMap()
        {
            return this.map.Name;
        }
        public Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = (int)(currentFrame.X * Define.UnitOFpixel);
                renderRectangle.Y = (int)(currentFrame.Y * Define.UnitOFpixel);
                return renderRectangle;
            }
        }
        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(position, GlobalController.Camera); }
        }
        public float LayerDepth
        {
            get
            {
                return 0.9f;
            }
        }
        public void Move()
        {
            Random ran = new Random();
            this.position.Y += 0.5f;
            if (this.position.Y % 8 == 3)
            {
                if (ran.Next(0, 100) > 50)
                {
                    this.position.X += 6;
                }
                else
                {
                    this.position.X -= 6;
                }
                if (ran.Next(0, 100) > 50)
                {
                    this.rotation += 0.15f;
                }
                else
                {
                    this.rotation -= 0.15f;
                }
            }
            if (this.position.Y >= this.disappear)
            {
                GlobalController.LeafList.Remove(this);
            }
        }
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
        }

        public Microsoft.Xna.Framework.Rectangle GetCollider()
        {
            throw new NotImplementedException();
        }

        public GameObject GetInstance()
        {
            return this;
        }

        public string GetIntanceType()
        {
            return "Leaf";
        }
    }
}
