using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Soils
{
    public class WCliff : GameObject, IGlobalScene
    {
        int type;
        Point currentFrame;


        public WCliff(Map map, int type, Texture2D texture, Vector2 position)
        {
            this.map = map;
            this.type = type;
            this.texture = texture;
            this.position = new Vector2(position.X * Define.UnitOFpixel, position.Y * Define.UnitOFpixel);

            this.size = new Point(4, 4);
            this.scale = 1;

            switch (type)
            {
                case 1: 
                    currentFrame = new Point(1, 1);
                    break;
                case 2:
                    currentFrame = new Point(2, 1);
                    break;
                case 3: 
                    currentFrame = new Point(3, 1);
                    break;
                case 4: 
                    currentFrame = new Point(4, 1);
                    break;
                case 5:
                    currentFrame = new Point(5, 1);
                    break;
                case 6:
                    currentFrame = new Point(6, 1);
                    break;
                case 7:
                    currentFrame = new Point(7, 1);
                    break;
                case 8:
                    currentFrame = new Point(8, 1);
                    break;
                case 9:
                    currentFrame = new Point(0, 1);
                    break;
                case 10:
                    currentFrame = new Point(9, 1);
                    break;
                default:
                    break;
            }

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel);
            this.renderColor = Color.White;

            
        }
        public Rectangle RenderRectangle
        {
            get
            {
                return new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel);
            }
        }

        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        public Vector2 RenderPosition
        {
            get
            {

                return Camera.HandlePos(new Vector2(this.position.X, this.position.Y),GlobalController.Camera);
            }
        }
        public float LayerDepth
        {
            get
            {
                return (float)((this.position.Y + 1) / Define.UnitOFpixel / map.Size.Y);
            }
        }

        public void Move()
        {
            if (this.currentFrame.Y == 1)
            {
                this.currentFrame.Y = 2;
            }
            else
            {
                this.currentFrame.Y = 1;
            }
        }

        public string GetMap()
        {
            return this.map.Name;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
        }

        public Rectangle GetCollider()
        {
            throw new NotImplementedException();
        }

        public GameObject GetInstance()
        {
            return this;
        }

        public string GetIntanceType()
        {
            return "WCliff";
        }
    }
}
