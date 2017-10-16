using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Soils
{
    public class Water: GameObject,IGlobalScene
    {
        Point currentFrame;
        float endDistance;

        public Water(Texture2D texture, Map map, Vector2 position, float endDistance,int current)
        {
            this.texture = texture;
            this.map = map;
            this.position = position;
            this.endDistance = endDistance;

            this.size = new Point(1, 1);
            this.scale = 1;
            
            this.currentFrame = new Point(current, 0);

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
            this.Collider = new Rectangle((int)this.Position.X, (int)this.Position.Y, Define.UnitOFpixel, Define.UnitOFpixel);
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
                //return (float)(this.position.Y / Define.UnitOFpixel / map.Size.Y) == 0 ? 0.000001f : (float)(this.position.Y / Define.UnitOFpixel / map.Size.Y) - 0.001f;
                return 0.000025f;
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
            return "Water";
        }

        public void Move()
        {
            this.position.X -= 0.2f;
            if (this.position.X < endDistance)
            {
                GlobalController.WaterList.Remove(this);
            }
        }
        public void NatureMove()
        {
            this.currentFrame.X += 1;
            if (this.currentFrame.X > 10)
            {
                this.currentFrame.X = 0;
            }
        }
    }
}
