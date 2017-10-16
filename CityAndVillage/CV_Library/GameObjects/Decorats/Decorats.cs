using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Decorats
{
    public class Decorats : GameObject, IGlobalScene
    {
        Point currentFrame;
        Point sheetSize;
        int style;
        bool collism;



        public Decorats(Map map, Texture2D texture, Vector2 position,int style)
        {
            this.map = map;
            this.texture = texture;
            this.position = new Vector2(position.X * Define.UnitOFpixel, position.Y * Define.UnitOFpixel);
            this.style = style;
            this.size = new Point(1, 1);
            this.scale = 1;
            switch (style)
            {
                case 1: currentFrame = new Point(1, 4);
                    collism = true;
                    collider = new Rectangle((int)position.X, (int)position.Y + Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
                    break;
                case 2: currentFrame = new Point(0, 3);
                    Collism = false;
                    collider = new Rectangle();
                    break;
                default:
                    collism = false;
                    collider = new Rectangle();
                    break;
            }
            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
            
        }

        public int Style
        {
            get { return style; }
            set { style = value; }
        }

        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        public bool Collism
        {
            get { return collism; }
            set { collism = value; }
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
            get { return Camera.HandlePos(new Vector2(this.position.X,this.position.Y), GlobalController.Camera); }
        }
        public float LayerDepth
        {
            get
            {
                return 0.1f;
            }
        }

        public new Rectangle Collider
        {
            get
            {
                collider.X = (int)position.X;
                collider.Y = (int)position.Y + Define.UnitOFpixel;
                return collider;
            }
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
            return "Decorats";
        }
    }
}
