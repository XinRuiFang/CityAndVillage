using CV_Library.Controllers;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Buildings
{
    public class Furniture : GameObject, IPlayerScene
    {
        string name;
        Point currentFrame;

        public Furniture(Texture2D texture, Map map, Vector2 position,Point size,Point currentFrame,Vector2 collidePos,Point collideSize,string name)
        {
            this.texture = texture;
            this.map = map;
            this.position = position;
            this.size = size;
            this.currentFrame = currentFrame;
            this.name = name;
            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, size.X * Define.UnitOFpixel, size.Y * Define.UnitOFpixel);
            this.collider = new Rectangle((int)(this.position.X + collidePos.X * Define.UnitOFpixel), (int)(this.position.Y + (1+collidePos.Y) * Define.UnitOFpixel), collideSize.X * Define.UnitOFpixel, collideSize.Y * Define.UnitOFpixel);
        }

        public static Furniture Null = null;

        public static Furniture CreateFurnitureFactory(Map map, Vector2 position, string name)
        {
            switch (name)
            {
                case "bed":
                    return new Furniture(ResourceController.Scenes_indoor_things, map, position, new Point(3, 4), new Point(0, 0), new Vector2(0, 1), new Point(3, 3), "bed");
                default:
                    return Furniture.Null;
            }

        }

        public override Map Map
        {
            get { return map; }
            set { map = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        public Rectangle RenderRectangle
        {
            get
            {
                return renderRectangle;
            }
        }

        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(new Vector2(position.X, position.Y), GlobalController.Camera); }
        }

        public override Rectangle Collider
        {
            get
            {
                return collider;
            }
        }
        public override Vector2 MidPos
        {
            get
            {
                midPos.X = Collider.X + Collider.Width / 2;
                midPos.Y = Collider.Y + Collider.Height / 2 - Define.UnitOFpixel - 4;
                return midPos;
            }
        }

        public float LayerDepth
        {
            get
            {
                return (this.position.Y + 1.5f * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }
        public string GetMap()
        {
            return this.map.Name;
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
        }

        public Microsoft.Xna.Framework.Rectangle GetCollider()
        {
            return this.collider;
        }

        public GameObject GetInstance()
        {
            return this;
        }

        public string GetIntanceType()
        {
            return "Furniture";
        }

        public string GetSaveParameter()
        {
            return this.map.Name + "|" + this.position.X + "|" + this.position.Y + "|" + this.name;
        }

        public Microsoft.Xna.Framework.Rectangle[] GetEffiveClickArea()
        {
            return new Rectangle[] { 
                new Rectangle(this.collider.X,this.collider.Y - Define.UnitOFpixel,this.collider.Width,this.collider.Height)
            };
        }
    }
}
