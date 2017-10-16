using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Globals
{
    public class Button : GameObject, IGlobalScene
    {
        Point currentFrame;
        string type;
        string bingFunc;
        float ld;
        string context;


        public Button(Texture2D texture,string type,string bingFunc,float ld,Vector2 position,string context = "")
        {
            this.position = position;
            this.scale = 2;
            this.texture = texture;
            this.type = type;
            this.bingFunc = bingFunc;
            this.ld = ld;
            this.context = context;
            switch (type.Substring(0,1))
            {
                case "1":
                    this.currentFrame = new Point(7, 11);
                    this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel);
                    break;
                case "2":
                    this.currentFrame = new Point(10, 11);
                    this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Define.UnitOFpixel * 3, Define.UnitOFpixel);
                    break;
                default:
                    break;
            }
            

            
            this.renderColor = Color.White;
        }


        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string BingFunc
        {
            get { return bingFunc; }
            set { bingFunc = value; }
        }

        public float LayerDepth
        {
            get
            {
                return ld;
            }
        }

        public string Context
        {
            get { return context; }
            set { context = value; }
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
            get { return Camera.HandlePos(new Vector2((this.position.X - 2) * Define.UnitOFpixel, (this.position.Y - 7) * Define.UnitOFpixel), GlobalController.Camera); }
        }

        public bool CheckPos(Vector2 clickPos)
        {
            switch (this.Type.Substring(0, 1))
            {
                case "1":
                    if ((this.position.X < clickPos.X && clickPos.X < this.position.X + 48) && (this.position.Y < clickPos.Y && clickPos.Y < this.position.Y + 48))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "2":
                    if ((this.position.X < clickPos.X && clickPos.X < this.position.X + 98) && (this.position.Y < clickPos.Y && clickPos.Y < this.position.Y + 48))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
            
        }


        public string GetMap()
        {
            throw new NotImplementedException();
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            b.Draw(this.Texture, this.Position, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
            switch (this.type)
            {
                case "2_1":
                    Fonts.DrawString("BUY", new Vector2(this.position.X + 30, this.position.Y + 10), b, new Color(235 / 255f, 166 / 255f, 101 / 255f), this.LayerDepth + 0.01f, 1, 100);
                    break;
                case "2_2":
                    Fonts.DrawString("WITHDRAW", new Vector2(this.position.X + 30, this.position.Y + 10), b, new Color(235 / 255f, 166 / 255f, 101 / 255f), this.LayerDepth + 0.01f, 0.5f, 100);
                    break;
                default:
                    break;
            }
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
            throw new NotImplementedException();
        }
    }
}
