using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Items
{
    public class OutDoorItem : GameObject, IPlayerScene
    {
        Item item;
        int initAnim;

        public OutDoorItem(Map map, Vector2 position, Item item)
        {
            this.map = map;
            this.position = position;
            this.item = item;
            this.initAnim = 0;
        }

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }


        public int InitAnim
        {
            get { return initAnim; }
            set { initAnim = value; }
        }


        public void ShowInitAnim()
        {
            if (initAnim == 0)
            {
                this.position.Y -= 12;
                initAnim ++;
            }
            else if (initAnim > 0 && initAnim <= 12)
            {
                this.position.Y += 1;
                initAnim++;
            }
            else if (initAnim > 12 && initAnim <= 18)
            {
                this.position.Y -= 1;
                initAnim++;
            }
            else if (initAnim > 18 && initAnim <= 24)
            {
                this.position.Y += 1;
                initAnim++;
            }
        }
        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(this.position, GlobalController.Camera); }
        }
        public string GetMap()
        {
            return this.map.Name;
        }
        public float LayerDepth
        {
            get
            {
                return 1f * this.position.Y / map.Size.Y / Define.UnitOFpixel;
            }
        }
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            b.Draw(this.item.Texture, this.RenderPosition, this.item.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, 1f, this.SpriteEffects, this.LayerDepth);
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
            return "OutDoorItem";
        }

        public string GetSaveParameter()
        {
            throw new NotImplementedException();
        }

        public Microsoft.Xna.Framework.Rectangle[] GetEffiveClickArea()
        {
            throw new NotImplementedException();
        }
    }
}
