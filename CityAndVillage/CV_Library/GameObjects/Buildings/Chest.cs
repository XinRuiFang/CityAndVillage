using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Buildings
{
    public class Chest : GameObject , IPlayerScene
    {
        int type;
        Point currentFrame;
        int amount;
        List<Inventory> inventries;


        public Chest(Map map, Vector2 position, Texture2D texture, int type)
        {
            this.map = map;
            this.position = new Vector2(position.X * Define.UnitOFpixel, position.Y * Define.UnitOFpixel);
            this.texture = texture;

            this.scale = 1;

            //1 -- salebox
            this.type = type;
            switch (type)
            {
                case 1:
                    currentFrame = new Point(0, 0);
                    break;
                default:
                    break;
            }
            this.amount = 18; //TODO

            this.renderRectangle = new Rectangle(0, 0, 3 * Define.UnitOFpixel, 5 * Define.UnitOFpixel);
            this.collider = new Rectangle(0, 0, 3 * Define.UnitOFpixel, 2 * Define.UnitOFpixel);

            this.inventries = new List<Inventory>();
            for (int i = 0; i < this.amount; i++)
            {
                this.inventries.Add(new Inventory(null, true, i + 1, 0));
            }
        }


        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public override Vector2 MidPos
        {
            get 
            {
                return new Vector2(this.Collider.X + this.Collider.Width / 2, this.Collider.Y + this.Collider.Height / 2- Define.UnitOFpixel - 4);
            }
            
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
                renderRectangle.X = (int)(CurrentFrame.X * 3 * Define.UnitOFpixel);
                renderRectangle.Y = (int)(CurrentFrame.Y * Define.UnitOFpixel);
                return renderRectangle;
            }
        }

        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(new Vector2(position.X, position.Y - 2 * Define.UnitOFpixel), GlobalController.Camera); }
        }

        public new Rectangle Collider
        {
            get
            {
                collider.X = (int)position.X;
                collider.Y = (int)position.Y + 2 * Define.UnitOFpixel;
                return collider;
            }
        }


        public List<Inventory> Inventries
        {
            get { return inventries; }
            set { inventries = value; }
        }
        public int Amount
        {
            get { return amount; }
        }

        public float LayerDepth
        {
            get
            {
                return 1f * (this.position.Y + 2 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }

        public string GetMap()
        {
            return this.Map.Name;
        }
        public void CheckPlayerNear()
        {
            float x = Math.Abs(GlobalController.Player.MidPos.X - this.MidPos.X);
            float y = Math.Abs(GlobalController.Player.MidPos.Y - this.MidPos.Y);
            if (Math.Sqrt(x * x + y * y) < 3 * Define.UnitOFpixel)
            {
                if (this.currentFrame.X < 4)
                {
                    this.currentFrame.X += 1;
                }
                
            }
            else
            {
                if (this.currentFrame.X > 0)
                {
                    this.currentFrame.X -= 1;
                }
            }
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
            return "Chest";
        }


        public string GetSaveParameter()
        {
            StringBuilder sb = new StringBuilder(this.Map.Name + "|" + ((int)(this.position.X / Define.UnitOFpixel)).ToString() + "|" + ((int)(this.position.Y / Define.UnitOFpixel)).ToString() + "|" + this.Type);
            for (int i = 0; i < this.Inventries.Count; i++)
            {
                if (!this.Inventries[i].IsNull)
                {
                    sb.Append("|");
                    sb.Append(this.Inventries[i].Item.Id.ToString());
                    sb.Append("^");
                    sb.Append(this.Inventries[i].Count.ToString());
                    sb.Append("^");
                    sb.Append(i.ToString());
                }
            }
            return sb.ToString();
        }


        public Rectangle[] GetEffiveClickArea()
        {
            switch (this.Type)
            {
                case 1:
                    
                    return new Rectangle[]
                    {
                        new Rectangle((int)this.Position.X,(int)this.Position.Y,this.RenderRectangle.Width,2 * Define.UnitOFpixel)
                    };
                default:
                    return null;
            }
        }
    }
}
