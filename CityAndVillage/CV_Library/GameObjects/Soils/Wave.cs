using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Soils
{
    public class Wave : GameObject, IGlobalScene
    {
        Point currentFrame;
        string id;

        //id : 1_1    1-top 2-bottom 3-left 4-right 5-corner(1-left-top 2-left-bottom 3-right-top 4-right-bottom)
        public Wave(Texture2D texture, Map map, Vector2 position,string id)
        {
            this.texture = texture;
            this.map = map;
            this.position = new Vector2(position.X * Define.UnitOFpixel, position.Y * Define.UnitOFpixel);
            this.id = id;

            switch (id)
            {
                case "1_1":
                    currentFrame = new Point(1, 3);
                    break;
                case "1_2":
                    currentFrame = new Point(2, 3);
                    break;
                case "1_3":
                    currentFrame = new Point(3, 3);
                    break;
                case "1_4":
                    currentFrame = new Point(4, 3);
                    break;
                case "2_1":
                    currentFrame = new Point(7, 3);
                    break;
                case "2_2":
                    currentFrame = new Point(8, 3);
                    break;
                case "2_3":
                    currentFrame = new Point(9, 3);
                    break;
                case "2_4":
                    currentFrame = new Point(10, 3);
                    break;
                case "3_1":
                    currentFrame = new Point(0, 10);
                    break;
                case "3_2":
                    currentFrame = new Point(0, 11);
                    break;
                case "3_3":
                    currentFrame = new Point(0, 12);
                    break;
                case "3_4":
                    currentFrame = new Point(0, 13);
                    break;
                case "4_1":
                    currentFrame = new Point(0, 14);
                    break;
                case "4_2":
                    currentFrame = new Point(0, 15);
                    break;
                case "4_3":
                    currentFrame = new Point(0, 16);
                    break;
                case "4_4":
                    currentFrame = new Point(0, 17);
                    break;
                case "5_1":
                    currentFrame = new Point(0, 3);
                    break;
                case "5_2":
                    currentFrame = new Point(6, 3);
                    break;
                case "5_3":
                    currentFrame = new Point(5, 3);
                    break;
                case "5_4":
                    currentFrame = new Point(11, 3);
                    break;
                case "5_5":
                    currentFrame = new Point(7, 10);
                    break;
                case "5_6":
                    currentFrame = new Point(8, 10);
                    break;
                case "5_7":
                    currentFrame = new Point(9, 10);
                    break;
                case "5_8":
                    currentFrame = new Point(10, 10);
                    break;
                default:
                    break;
            }

            this.size = new Point(1, 1);
            this.scale = 1;
            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
            this.collider = new Rectangle((int)this.Position.X, (int)this.Position.Y + Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel);
        }

        public new Rectangle Collider
        {
            get { return collider; }
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

        public void Move()
        {
            switch (id)
            {
                case "1_1":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "1_2":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "1_3":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "1_4":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "2_1":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "2_2":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "2_3":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "2_4":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "3_1":
                    this.currentFrame.X += 1;
                    if (this.currentFrame.X > 6)
                    {
                        this.currentFrame.X = 0;
                    }
                    break;
                case "3_2":
                    this.currentFrame.X += 1;
                    if (this.currentFrame.X > 6)
                    {
                        this.currentFrame.X = 0;
                    }
                    break;
                case "3_3":
                    this.currentFrame.X += 1;
                    if (this.currentFrame.X > 6)
                    {
                        this.currentFrame.X = 0;
                    }
                    break;
                case "3_4":
                    this.currentFrame.X += 1;
                    if (this.currentFrame.X > 6)
                    {
                        this.currentFrame.X = 0;
                    }
                    break;
                case "4_1":
                    this.currentFrame.X += 1;
                    if (this.currentFrame.X > 6)
                    {
                        this.currentFrame.X = 0;
                    }
                    break;
                case "4_2":
                    this.currentFrame.X += 1;
                    if (this.currentFrame.X > 6)
                    {
                        this.currentFrame.X = 0;
                    }
                    break;
                case "4_3":
                    this.currentFrame.X += 1;
                    if (this.currentFrame.X > 6)
                    {
                        this.currentFrame.X = 0;
                    }
                    break;
                case "4_4":
                    this.currentFrame.X += 1;
                    if (this.currentFrame.X > 6)
                    {
                        this.currentFrame.X = 0;
                    }
                    break;
                case "5_1":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "5_2":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "5_3":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "5_4":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 9)
                    {
                        this.currentFrame.Y = 3;
                    }
                    break;
                case "5_5":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 16)
                    {
                        this.currentFrame.Y = 10;
                    }
                    break;
                case "5_6":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 16)
                    {
                        this.currentFrame.Y = 10;
                    }
                    break;
                case "5_7":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 16)
                    {
                        this.currentFrame.Y = 10;
                    }
                    break;
                case "5_8":
                    this.currentFrame.Y += 1;
                    if (this.currentFrame.Y > 16)
                    {
                        this.currentFrame.Y = 10;
                    }
                    break;
                default:
                    break;
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
            return this.Collider;
        }

        public GameObject GetInstance()
        {
            return this;
        }

        public string GetIntanceType()
        {
            return "Wave";
        }

    }
}
