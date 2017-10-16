using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Bush : GameObject, IGlobalScene
    {
        int style;
        Point currentFrame;
        Point sheetSize;

        public Bush(Map map,int style,Texture2D texture,Vector2 position)
        {
            this.map = map;
            this.style = style;
            this.texture = texture;
            this.position = position;

            this.size = new Point(4, 4);
            this.scale = 1;
          
            switch (style)
            {
                case 1: 
                    currentFrame = new Point(0, 0);
                    this.collider = new Rectangle((int)(this.position.X * Define.UnitOFpixel), (int)(this.position.Y * Define.UnitOFpixel), 2 * Define.UnitOFpixel,  Define.UnitOFpixel);
                    break;
                case 2:
                    currentFrame = new Point(4, 0);
                    this.collider = new Rectangle((int)(this.position.X * Define.UnitOFpixel), (int)(this.position.Y * Define.UnitOFpixel), 2 * Define.UnitOFpixel,  Define.UnitOFpixel);
                    break;
                case 4: 
                    currentFrame = new Point(0, 4);
                    this.collider = new Rectangle((int)((this.position.X-1) * Define.UnitOFpixel), (int)(this.position.Y * Define.UnitOFpixel), 3 * Define.UnitOFpixel,  Define.UnitOFpixel);
                    break;
                case 5: 
                    currentFrame = new Point(4, 4);
                    this.collider = new Rectangle((int)((this.position.X-1) * Define.UnitOFpixel), (int)(this.position.Y * Define.UnitOFpixel), (int)(3 * Define.UnitOFpixel),  Define.UnitOFpixel);
                    break;
                case 3:
                    currentFrame = new Point(8, 0);
                    this.collider = new Rectangle((int)(this.position.X * Define.UnitOFpixel), (int)(this.position.Y * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
                    break;
                default:
                    break;
            }
            sheetSize = new Point(8, 8);

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
            this.renderColor = Color.White;

            
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
            get {

                        return Camera.HandlePos(new Vector2((this.position.X - 1) * Define.UnitOFpixel, (this.position.Y - 3) * Define.UnitOFpixel), GlobalController.Camera);            
            }
        }
        public float LayerDepth
        {
            get
            {
                return (float)(this.position.Y / map.Size.Y);
            }
        }
        public new Rectangle Collider
        {
            get { return collider; }
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
            return "Bush";
        }
    }
}
