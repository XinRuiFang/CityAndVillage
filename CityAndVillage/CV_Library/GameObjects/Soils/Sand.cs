using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Soils
{
    public class Sand : GameObject, IGlobalScene
    {
        Point currentFrame;
        string type;

        public Sand(Texture2D texture, Map map, Vector2 position,string type)
        {
            this.texture = texture;
            this.map = map;
            this.position = new Vector2(position.X * Define.UnitOFpixel, position.Y * Define.UnitOFpixel);
            this.size = new Point(1, 1);
            this.scale = 1;
            this.type = type;

            if (type == "1")
            {
                this.currentFrame = new Point(8, 0);
            }
            else
            {
                this.currentFrame = new Point(10, 0);
            }
            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
        }

        public Point CurrentFrame
        {
            get
            {
                return currentFrame;
            }
        }
        public Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = CurrentFrame.X * Define.UnitOFpixel;
                renderRectangle.Y = CurrentFrame.Y * Define.UnitOFpixel;
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
                return (float)(this.position.Y / Define.UnitOFpixel / map.Size.Y) == 0 ? 0.00001f : (float)(this.position.Y / Define.UnitOFpixel / map.Size.Y);
            }
        }

        public string GetMap()
        {
            return Map.Name;
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
            return "Sand";
        }
    }
}
